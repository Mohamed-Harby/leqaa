using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Stripe;
using System.Drawing.Drawing2D;

namespace Payment_GateWay.Main.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        private IConfiguration configuration;

        public DbSet<UserPlan> Products => Set<UserPlan>();

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {

            this.configuration = configuration;
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const int amountOfProductsToSeed = 1;

            var productsToSeed = new UserPlan[amountOfProductsToSeed];

            for (int i = 1; i <= amountOfProductsToSeed; i++)
            {
                productsToSeed[i - 1] = new UserPlan
                {
                    Id = i*5,
                    User="palnUserName",
                    PlanType = "Premium",
                    Price= i*5,
                  
                };
            }

            modelBuilder.Entity<UserPlan>().HasData(productsToSeed);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext)
        {
            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated();
        }
    }
}
