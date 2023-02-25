namespace BusinessLogic.Domain.Plan;
public class Plan : BaseEntity
{
    public Plan()
    {

    }
    public Plan(Guid userId, PlanType planType)
    {
        UserId = userId;
        Type = planType;
    }
    public PlanType Type { get; set; } = PlanType.Free;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}