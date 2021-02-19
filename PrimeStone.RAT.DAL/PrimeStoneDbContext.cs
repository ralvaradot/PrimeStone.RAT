using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeStone.RAT.Entities;
using System;

namespace PrimeStone.RAT.DAL
{
    public class PrimeStoneDbContext : IdentityDbContext<IdentityUser>
    {
        public PrimeStoneDbContext() { }
        public PrimeStoneDbContext(DbContextOptions<PrimeStoneDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SUV1NUE;Database=PrimeStoneRATPrbTecnica;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<IdentityUser> ApplicationUser { get; set; }

        public DbSet<IdentityUserClaim<Guid>> IdentityUserClaims { get; set; }
        public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

    }
}
