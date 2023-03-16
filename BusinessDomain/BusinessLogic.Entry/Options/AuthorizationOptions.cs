using BusinessLogic.Infrastructure.Authorization.Enums;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace BusinessLogic.Entry.Options;
public class AuthorizationOptionsSetup : IConfigureOptions<AuthorizationOptions>
{
    public void Configure(AuthorizationOptions options)
    {
        string canDeployHubs = Permission.CanDeployHubs.ToString();
        options.AddPolicy(canDeployHubs, builder =>
        {
            builder.AddRequirements(new CanDeployHubsRequirement(canDeployHubs));
        });

        string CanCreateChannel = Permission.CanCreateChannel.ToString();
        options.AddPolicy(CanCreateChannel, builder =>
        {
            builder.AddRequirements(new CanCreateChannelsRequirement(CanCreateChannel));
        });

        string canJoinRoom = Permission.CanJoinRoom.ToString();
        options.AddPolicy(canJoinRoom, builder =>
        {
            builder.AddRequirements(new CanJoinRoomRequirement(canJoinRoom));
        });

        string canJoinHub = Permission.CanJoinHub.ToString();
        options.AddPolicy(canJoinHub, builder =>
        {
            builder.AddRequirements(new CanJoinHubRequirement(canJoinHub));
        });
    }
}
