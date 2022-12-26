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


    }

}