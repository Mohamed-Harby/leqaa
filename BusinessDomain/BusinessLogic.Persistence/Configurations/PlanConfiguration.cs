using BusinessLogic.Domain.Plan;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class PlanConfiguration : BaseConfiguration<Plan>
{
    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        base.Configure(builder);
    }
}