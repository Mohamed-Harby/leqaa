using Microsoft.EntityFrameworkCore;
using Payment_GateWay.Main.Data;
using Stripe;
using System.Configuration;
using System;
using Payment_Gateway.main.Data.Repository;
using shared.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IUserPlanRepository, UserPlanRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite("DataSource=:memory:"));*/
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    var con = builder.Configuration.GetConnectionString("DefaultConnection");
    System.Console.WriteLine(con);

    Options.UseMySql(con, ServerVersion.AutoDetect(con));
});

var app = builder.Build();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>()!;

    context.Database.Migrate();

}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseRouting();

app.MapControllers();

app.Run();
