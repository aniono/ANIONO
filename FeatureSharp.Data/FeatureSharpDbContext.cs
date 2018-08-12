using FeatureSharp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace FeatureSharp.Data
{
    public class FeatureSharpDbContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }

        public FeatureSharpDbContext()
        { }

        public FeatureSharpDbContext(DbContextOptions<FeatureSharpDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Server=(localdb)\mssqllocaldb;Database=FeatureSharpDb;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
