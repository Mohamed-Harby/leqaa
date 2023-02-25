using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Plans;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.Plan;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.BuyPlan;
public record BuyPlanCommand(
    string PlanType,
    string UserName
) : ICommand<ErrorOr<PlanReadModel>>;