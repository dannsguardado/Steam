﻿using STEAM.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace STEAM.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<Contact> Contacts => Set<Contact>();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}
