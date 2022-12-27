using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class PostConfiguration : BaseConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("posts");

        base.Configure(builder);

        builder.Property(t=>t.Title).IsRequired()
        .HasMaxLength(30);
        builder.Property(t=>t.Content).IsRequired()
        .HasMaxLength(1000);




    }

}