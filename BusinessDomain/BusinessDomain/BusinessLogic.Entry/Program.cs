using BusinessLogic.Application.DependencyInjection;
using BusinessLogic.Entry.ServiceConfigurations;
using BusinessLogic.Infrastructure.DependencyInjection;
using BusinessLogic.Persistence.DependencyInjection;
using BusinessLogic.Presentation.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging((ctx, lc) =>
{
    lc.AddConsole();
});

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(HubController).Assembly)
.AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication()
    .AddInfrastructure();
    
builder.Services.AddCorsConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(CorsConfiguration.CorsPolicyName);
app.MapControllers();

app.Run();
