using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using firstMvcApp.Models;

namespace firstMvcApp.Infrastructure
{
    public class NorthwindContext : DbContext
    {
        // Table - Products
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}