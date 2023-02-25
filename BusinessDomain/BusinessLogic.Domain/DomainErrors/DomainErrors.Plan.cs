using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static partial class Plan
    {
        public static Error InvalidPlan => Error.Failure("Plan.InvalidPlan", "Invalid plan, please check your input");
    }
}