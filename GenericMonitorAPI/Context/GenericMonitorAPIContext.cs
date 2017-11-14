﻿using System.Data.Entity;
using GenericMonitorAPI.Models;

namespace GenericMonitorAPI.Context
{
    public class GenericMonitorAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GenericMonitorAPIContext() : base("name=GenericMonitorAPIContext")
        {
        }

        public DbSet<Monitorization> Monitorizations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

    }
}
