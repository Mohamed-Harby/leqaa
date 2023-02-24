namespace BusinessLogic.Domain.Plan;
public class Plan : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}