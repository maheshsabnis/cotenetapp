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
    public class CategoryServiceRepository
        : IServiceRepository<Category, int>
    {
        private readonly MyAppDbContext ctx;

        public CategoryServiceRepository(MyAppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<Category> CreateAsync(Category entity)
        {
            var res = await ctx.Categories.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await ctx.Categories.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            ctx.Categories.Remove(entity);
            await ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var entities = await ctx.Categories.ToListAsync();
            return entities;
        }

        public async Task<Category> GetAsync(int id)
        {
            var entity = await ctx.Categories.FindAsync(id);
            return entity;
        }

        public async Task<Category> UpdateAsync(int id, Category entity)
        {
            var res = await ctx.Categories.FindAsync(id);
            if(res != null)
            { 
                ctx.Update<Category>(entity).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
            return entity;
            
        }
    }
}
