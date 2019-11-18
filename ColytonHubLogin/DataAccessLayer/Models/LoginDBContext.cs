using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColytonHubLogin.DataAccessLayer.Models
{
    public class LoginDBContext : DbContext
    {
        public DbSet<LoginDetail> LoginDetails { get; set; }

        public LoginDBContext(DbContextOptions<LoginDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginDetail>().HasKey(c => c.Id);
        }
    }
}
