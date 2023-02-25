using BusinessLogic.Domain.Plan;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class PlanConfiguration : BaseConfiguration<Plan>
{
    public override void Configure(EntityTypeBuilder<Plan> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Type).IsRequired();
        builder
        .HasOne(p => p.User)
        .WithMany(u => u.Plans)
        .HasForeignKey(p => p.UserId);
    }
}