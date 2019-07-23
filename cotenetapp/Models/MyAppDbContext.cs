using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotenetapp.Models
{
    /// <summary>
    /// This class is used as DAL class for
    /// 1. Data Connection
    /// 2. Model Mapping
    /// 3. Provide Connection String to the constructor using 
    /// DbContextOptions<T> class where T is DbContext Type
    /// The Parameter to the ctor must be set 
    /// using DI of ASP.NET Core. The DbContext must be registered 
    /// in DI and Connection string must be passed to it
    /// </summary>
    public class MyAppDbContext : DbContext
    {
        // Define DbSet<T> for Entity to Table Mapping
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Read the Connection string from StartUp.cs
        /// and Map with Database for Transactions
        /// </summary>
        /// <param name="options"></param>
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {

        }

        // override the OnModelCreating() method to Create
        // Tables Maped with models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
