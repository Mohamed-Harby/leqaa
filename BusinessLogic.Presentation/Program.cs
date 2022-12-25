using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repositories;
using BusinessLogic.Persistence.UnitsOfWork;
using BusinessLogic.Presentation.ServiceConfigurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextConfiguration(builder.Configuration);

builder.Services.AddUserRepository();
builder.Services.AddRoomRepository();
builder.Services.AddChannelRepository();
builder.Services.AddHubRepository();
builder.Services.AddPostRepository();
builder.Services.AddAnnouncementRepository();
builder.Services.AddUnitOfWork();

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


var user = new User
{
    Name = "ASDF",
    Email = "ASDF@gmail.com",
    Password = "ASDF",
    Gender = Gender.male,
    Username = "ASDF",
};
var serviceProvider = builder.Services.BuildServiceProvider();
IHubRepository hubRepository = (serviceProvider.GetService(typeof(IHubRepository)) as HubRepository)!;
// var medhat = dbContext.users!.FirstOrDefault(u => u.Name == "Medhat");
// var reda = dbContext.users.FirstOrDefault(u => u.Id == Guid.Parse("fc9a4864-d149-47a7-954f-600ce4b0db10"));
// medhat.Followers.Add(reda);

await hubRepository.AddAsync(new Hub
{
    Name = "Hub1"

});
IUnitOfWork? unitOfWork = (serviceProvider.GetService(typeof(IUnitOfWork)) as UnitOfWork)!;
await unitOfWork.Save();

// app.Run();
