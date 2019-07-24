using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cotenetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cotenetapp.Services
{
    /// <summary>
    /// The Respository class for
    /// CRUD Operations on Category.
    /// This class will be Constructor Injecte
    /// using MyAppDbContext class that is registered
    /// in ConfigureServices() method of Stsrtup.cs
    /// .This repository must be registered in Services
    /// of Startup.cs
    /// </summary>
    public class ProductServiceRepository
        : IServiceRepository<Product, int>
    {
        private readonly MyAppDbContext ctx;

        public ProductServiceRepository(MyAppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Product> CreateAsync(Product entity)
        {
            var res = await ctx.Products.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await ctx.Products.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            ctx.Products.Remove(entity);
            await ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            var entities = await ctx.Products.ToListAsync();
            return entities;
        }

        public async Task<Product> GetAsync(int id)
        {
            var entity = await ctx.Products.FindAsync(id);
            return entity;
        }

        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            var res = await ctx.Products.FindAsync(id);
            if(res != null)
            { 
                ctx.Update<Product>(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
            return entity;
            
        }
    }
}
