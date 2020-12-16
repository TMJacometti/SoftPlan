using Microsoft.EntityFrameworkCore;
using SoftPlan.Domain.Entities;
using SoftPlan.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Infra.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ThiagoJacometti\source\repos\TMJacometti\SoftPlan\SoftPlan.Infra.Data\Database\SoftPlanDB.mdf;Integrated Security=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);

        }
    }
}
