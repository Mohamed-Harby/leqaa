using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment_GateWay.Main.Data;
using Shared.Models;
using Stripe;
using System;

namespace Payment_Gateway.main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlansController : ControllerBase
    {


  

        private readonly ApplicationDbContext _appDbContext;

        public PlansController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserPlan productToCreate)
        {
          

            await _appDbContext.AddAsync(productToCreate);

            await _appDbContext.SaveChangesAsync();

            return Ok(productToCreate);
        }

        [HttpGet]
        public async Task<IEnumerable<UserPlan>> Get()
        {
            return await _appDbContext.Products.ToListAsync();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserPlan updatedProduct)
        {
            _appDbContext.Update(updatedProduct);

            await _appDbContext.SaveChangesAsync();

            return Ok(updatedProduct);
        }

        [HttpDelete]
        [Route("{productToDeleteId}")]
        public async Task<IActionResult> Update(string productToDeleteId)
        {
            var productToDelete = await _appDbContext.Products.FindAsync(productToDeleteId);

            _appDbContext.Remove(productToDelete);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}

