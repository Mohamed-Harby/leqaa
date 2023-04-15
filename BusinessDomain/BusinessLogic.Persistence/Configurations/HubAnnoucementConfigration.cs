using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Configurations
{
    public class HubAnnoucementConfigration : BaseConfiguration<HubAnnouncement>
    {

        public override void Configure(EntityTypeBuilder<HubAnnouncement> builder)
        {
            builder.ToTable("HubAnnouncement");
            base.Configure(builder);
            builder
            .HasOne(r => r.Hub)
            .WithMany(u => u.HubAnnouncements)
            .OnDelete(DeleteBehavior.Cascade);




        }


    }
}
