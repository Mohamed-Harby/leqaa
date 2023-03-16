using BusinessLogic.Application;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Enums;
using BusinessLogic.Shared;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence;
public static class DataSeeder
{
    public static async Task<ModelBuilder> SeedDataAsync(this ModelBuilder modelBuilder)
    {
        var seedUser = new User
        {
            Id = Constants.DefaultId,
            Name = "Leqaa",
            UserName = "Leqaa",
            Email = "Leqaa.Technical@gmail.com",
            Gender = Gender.female,
        };
        var seedHub = new Hub
        {
            Id = Constants.DefaultId,
            Name = "Main Hub",
            Description = "The main hub of Leqaa-Conferencing Application, Here goes all channels without a hub",
            Logo = await FileManager.GetByteArrayFromImageStaticAsync(Path.Combine(Environment.CurrentDirectory, "../Assets/HubPlaceHolder.png"))
        };
        var seedChannel = new Channel
        {
            Id = Constants.DefaultId,
            Name = "Main Channel",
            HubId = Constants.DefaultId,
            Description = "The main channel of Leqaa-Conferencing Application, Here goes all rooms without a channel",
        };
        var seedRoom = new Room
        {
            Id = Constants.DefaultId,
            ChannelId = Constants.DefaultId,
            Description = "First room"
        };
        modelBuilder.Entity<User>().HasData(seedUser);
        modelBuilder.Entity<Hub>().HasData(seedHub);
        modelBuilder.Entity<Channel>().HasData(seedChannel);
        modelBuilder.Entity<Room>().HasData(seedRoom);
        return modelBuilder;
    }
}
