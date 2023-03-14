namespace Shared.Models
{
    public class UserPlan
    {
        public int Id { get; set; }

        public string? User{ get; set; }

        public string PlanType { get; set; } = "premium";

        public long?Price { get; set; }

  
      
    }
}
