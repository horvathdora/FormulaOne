﻿using Formula1_WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Formula1_WebApplication
{
    public class FormulaOneContext : IdentityDbContext<IdentityUser>
    {
        public FormulaOneContext (DbContextOptions<FormulaOneContext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<IdentityUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<IdentityUser>().ToTable("User");
        }
    }
}
