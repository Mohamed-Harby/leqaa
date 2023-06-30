using BusinessLogic.Entry.Options;
using BusinessLogic.Application.DependencyInjection;
using BusinessLogic.Entry.Models;
using BusinessLogic.Entry.ServiceConfigurations;
using BusinessLogic.Infrastructure.DependencyInjection;
using BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.DependencyInjection;
using BusinessLogic.Presentation.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using System.Text;

using Microsoft.Graph.ExternalConnectors;
using Microsoft.Extensions.Options;

using BusinessLogic.Infrastructure.NetworkCalls.MessageQueue.Models;
using Serilog;
using BusinessLogic.Entry.ConsulConfigurations;
using Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    //i want to set the value of the serverUrl from the appsettings.json file if it's not set before
    if (context.Configuration["Serilog:WriteTo:1:Args:serverUrl"] == "${SEQ_URL}")
        context.Configuration["Serilog:WriteTo:1:Args:serverUrl"] = "http://localhost:5341";
    Console.WriteLine("====" + context.Configuration["Serilog:WriteTo:1:Args:serverUrl"] + "====");
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.AddApplicationPart(typeof(HubController).Assembly)
.AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddStackExchangeRedisCache(options =>
{


 string connection = builder.Configuration.GetConnectionString("Redis");
    options.Configuration = connection;

});
builder.Services.AddDistributedMemoryCache();
builder.Services.ConfigureOptions<SwaggerGenOptionsSetup>();
builder.Services.ConfigureOptions<AuthorizationOptionsSetup>();
/*builder.Services.AddSingleton<IHostedService, ConsulHostedService>();*/
/*builder.Services.Configure<ConsulConfig>(builder.Configuration.GetSection("Consul"));*/
/*builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
{
    var address = builder.Configuration["Consul:address"];
    consulConfig.Address = new Uri(address);
}));
*/
builder.Services.AddSwaggerGen();
builder.Services
    .AddPersistence(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services.AddCoreAdmin();

Jwt jwt = new();
builder.Configuration.GetSection("Jwt").Bind(jwt);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        ValidateIssuer = true,
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
        ValidateIssuerSigningKey = true,
    };
    System.Console.WriteLine(jwt.Audience);
});

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<RabbitMQConnection>(
    builder.Configuration.GetSection("RabbitMQConnection")
    );

builder.Services.AddCorsConfiguration();
builder.Services.AddAuthorization();

try
{
    RabbitMQConnector rabbitMQConnector = new();
    IModel channel = await rabbitMQConnector.ConnectAsync(builder.Configuration);
    await MessageQueueHelper.SubscribeToRegisterUsersQueue(channel, builder!.Services.BuildServiceProvider());
}
catch (Exception ex)
{
    System.Console.WriteLine(ex.ToString());
}
var app = builder.Build();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>()!;

    context.Database.Migrate();

}
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseCors(CorsConfiguration.CorsPolicyName);
app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
