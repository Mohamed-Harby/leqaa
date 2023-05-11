namespace BusinessLogic.Application.Models.Users;
public record AddUserToHubModel(
    string AddedUser,
    Guid? HubId);