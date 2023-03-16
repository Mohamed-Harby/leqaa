using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Domain.Entities.ApplicationUser;

using Microsoft.EntityFrameworkCore;
using Authentication.Domain.Entities.ApplicationUser.Enums;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;database=LeqaaAuthentication;Uid=root;pwd=2510203121";
                optionsBuilder.UseMySql(connectionString,
                                  ServerVersion.AutoDetect(connectionString))
                                  .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var hasher = new PasswordHasher<ApplicationUser>();
            var seedApplicationUser = new ApplicationUser
            {
                Name = "Leqaa",
                Email = "Leqaa.Technical@gmail.com",
                Gender = Gender.Female,
                EmailConfirmed = true,
                NormalizedEmail = "LEQAA.TECHNICAL@GMAIL.COM",
                UserName = "Leqaa",
                NormalizedUserName = "LEQAA",
                PasswordHash = hasher.HashPassword(null!, "P@ssw0rd123")
            };
            modelBuilder.Entity<ApplicationUser>().HasData(seedApplicationUser);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
