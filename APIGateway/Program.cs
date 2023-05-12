using AuthenticationOptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;
using static AuthenticationOptions.JwtBearerOptionsSetup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddSwaggerGen();
var env = builder.Environment.EnvironmentName;
builder.Configuration
    .AddJsonFile($"ocelot.{env}.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
Jwt jwt = new();
builder.Configuration.GetSection("Jwt").Bind(jwt);
builder.Services.AddMvc();

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Configuration.AddJsonFile("launchSettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"launchSettings.{Environment.GetEnvironmentVariable("environmentVariables") ?? "development"}.json", optional: true)
    .AddEnvironmentVariables();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        ValidateAudience = true,
        ValidateIssuer = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
        ValidateIssuerSigningKey = true
    };
});
var x=System.Environment.GetEnvironmentVariable("DownstreamHost");
var myVarValue =Environment.GetEnvironmentVariable("BaseUrl");
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
await app.UseOcelot();

app.Run();
