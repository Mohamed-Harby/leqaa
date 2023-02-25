using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.Plan;
using Mapster;
using BusinessLogic.Application.Models.Plans;

namespace BusinessLogic.Application.Commands.Users.BuyPlan;
public class BuyPlanCommandHandler : IHandler<BuyPlanCommand, ErrorOr<PlanReadModel>>
{
    private readonly IPlanRepository _planRepository;
    private readonly IUserRepository _userRepository;

    public BuyPlanCommandHandler(IPlanRepository planRepository, IUserRepository userRepository)
    {
        _planRepository = planRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<PlanReadModel>> Handle(BuyPlanCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault();
        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }
        PlanType planType = PlanType.Free;
        if (!Enum.TryParse<PlanType>(
            value: request.PlanType,
            ignoreCase: true,
            result: out planType))
        {
            return DomainErrors.Plan.InvalidPlan;
        }
        var plan = new Plan(
            userId: user.Id,
            planType: planType);
        await _planRepository.AddAsync(plan);
        if (await _planRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Plan.InvalidPlan;
        }
        return plan.Adapt<PlanReadModel>();
    }
}
