namespace Shared.Models.Dto
{
    public class UserPlanDto
    {
        public int Id { get; set; }

        public string? UserToken{ get; set; }

        public string PlanType { get; set; } = "premium";

        public long?Price { get; set; }

  
      
    }
}
