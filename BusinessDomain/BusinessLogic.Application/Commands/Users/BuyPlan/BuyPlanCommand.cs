using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Plans;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.BuyPlan;
public record BuyPlanCommand(
    string PlanType,
    string UserName
) : IUserNameInCommand<ErrorOr<PlanReadModel>>;