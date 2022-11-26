using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
   public class NorthWindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(LocalDb)\MSSQLLocalDB;initial catalog=northwind;integrated security=true");

            //optionsBuilder.UseSqlServer(connectionString: @"Server=(LocalDb)\MSSQLLocalDB; Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
