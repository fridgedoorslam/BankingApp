﻿using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Share> Shares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Share>().ToTable("Shares");
        }
    }
}
