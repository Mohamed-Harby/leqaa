using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.BuyPlan;
public record BuyPlan(
    string PlanName,
    string UserName
) : ICommand<ErrorOr<UserReadModel>>;