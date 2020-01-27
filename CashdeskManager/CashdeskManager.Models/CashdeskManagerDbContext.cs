using CashdeskManager.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashdeskManager.Models
{
    public class CashdeskManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CashMachineOpened> CashMachinesOpened { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.IsAdministrator).HasDefaultValue(false);

            modelBuilder.Entity<User>()
                .HasMany(x => x.CashMachineOpened)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

        }
    }
}
