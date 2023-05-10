namespace Shared.Models.Services
{
    public class StripeSettings
    {

        public string? SessionId { get; set; }
        public string? PubKey { get; set; }
        public string? Secret { get; set; } = null;

        public string? userName { get; set; }
      
    }
}
