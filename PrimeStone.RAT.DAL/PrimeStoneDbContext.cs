using Microsoft.EntityFrameworkCore;
using PrimeStone.RAT.Entities;

namespace PrimeStone.RAT.DAL
{
    public class PrimeStoneDbContext : DbContext
    {
        public PrimeStoneDbContext() { }
        public PrimeStoneDbContext(DbContextOptions<PrimeStoneDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SUV1NUE;Database=PrimeStoneRATPrbTecnica;Trusted_Connection=True;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
