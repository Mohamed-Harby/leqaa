using BusinessLogic.Entry.Options;
using BusinessLogic.Application.DependencyInjection;
using BusinessLogic.Entry.Models;
using BusinessLogic.Entry.ServiceConfigurations;
using BusinessLogic.Infrastructure.DependencyInjection;
using BusinessLogic.Infrastructure.Models;
using BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.DependencyInjection;
using BusinessLogic.Presentation.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessLogic.Entry.JsonConfigurations;


var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging((ctx, lc) =>
{
    lc.AddConsole();
});

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.AddApplicationPart(typeof(HubController).Assembly)
.AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureOptions<SwaggerGenOptionsSetup>();
builder.Services.ConfigureOptions<AuthorizationOptionsSetup>();

builder.Services.AddSwaggerGen();
builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication()
    .AddInfrastructure();

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
        IssuerSigningKey = new SymmetricSecurityKey(Base64UrlEncoder.DecodeBytes(jwt.Key)),
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<RabbitMQConnection>(
    builder.Configuration.GetSection("RabbitMQConnection")
    );

builder.Services.AddCorsConfiguration();
#pragma warning disable
builder.Services.AddAuthorization();

try
{
    IModel channel = RabbitMQConfiguration.ConnectToRabbitMQ(builder.Configuration);
    MessageQueueHelper.SubscribeToRegisterUsersQueue(channel, builder.Services.BuildServiceProvider());
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
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(CorsConfiguration.CorsPolicyName);
app.MapControllers();

app.Run();
