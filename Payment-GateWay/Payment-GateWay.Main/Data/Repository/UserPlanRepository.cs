using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Payment_Gateway.main.Data.Repository;
using Payment_GateWay.Main.Data;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shared.Repository
{
    public class UserPlanRepository : IUserPlanRepository
    {

        private readonly ApplicationDbContext _context;
        protected readonly DbSet<UserPlan> table;
        public UserPlanRepository(ApplicationDbContext context) 
        {

            _context = context;
            this.table = context.Set<UserPlan>();
        }

       

     

        public async Task<string> GetAsync(string username)
        {
            if (username == null)
            {
                return "not valid user name";
            }
            UserPlan user = (await table.Where(u => u.User == username).FirstOrDefaultAsync())!;
            var PlanType = user.PlanType;
            return PlanType;
        }
        public virtual async Task SaveAsync( )
        {
             await _context.SaveChangesAsync();
        }



        public virtual async Task<UserPlan> AddAsync(UserPlan entity)
        {
            await table.AddAsync(entity);

            return entity;
        }

      
    }
}