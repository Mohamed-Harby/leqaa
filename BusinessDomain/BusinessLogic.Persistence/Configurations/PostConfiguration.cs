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


        builder
   .HasMany(h => h.PostPinningUsers)
   .WithMany(u => u.PinnedPosts)
   .UsingEntity<UserPinnedPost>(
       join => join
       .HasOne(uh => uh.UserPinned)
       .WithMany()
       .HasForeignKey(uh => uh.UserPinnedId)
            .OnDelete(DeleteBehavior.Cascade),

       join => join
       .HasOne(uh => uh.PinnedPost)
       .WithMany()
       .HasForeignKey(uh => uh.PinnedPostId)
            .OnDelete(DeleteBehavior.Cascade)
   );



        builder.Property(t=>t.Title).IsRequired()
        .HasMaxLength(30);
        builder.Property(t=>t.Content).IsRequired()
        .HasMaxLength(1000);




    }

}