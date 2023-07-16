﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.Models;
using System.Linq.Expressions;

namespace Payment_Gateway.main.Data.Repository
{

    public interface IUserPlanRepository 
    {

        public Task<string> GetAsync(string username);
        public Task<UserPlan> AddAsync(UserPlan entity);
        public Task<bool> Find(string username);
        public Task<string> BackToFree(string userName);
        Task SaveAsync();
    }

}
