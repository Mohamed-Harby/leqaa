using BusinessLogic.Domain;
using BusinessLogic.Persistence;
using BusinessLogic.Presentation.ServiceConfigurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var databaseOptions = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
var dbContext = new ApplicationDbContext(databaseOptions);
var user = new User
{
    Name = "ASDF",
    Email = "ASDF@gmail.com",
    Password = "ASDF",
    Gender = Gender.male,
    Username = "ASDF",
};
dbContext.users.Add(user);

// var medhat = dbContext.users!.FirstOrDefault(u => u.Name == "Medhat");
// var reda = dbContext.users.FirstOrDefault(u => u.Id == Guid.Parse("fc9a4864-d149-47a7-954f-600ce4b0db10"));
// medhat.Followers.Add(reda);

dbContext.SaveChanges();
var x = dbContext.ChangeTracker.DebugView.ShortView;
int y = 10;
// app.Run();
