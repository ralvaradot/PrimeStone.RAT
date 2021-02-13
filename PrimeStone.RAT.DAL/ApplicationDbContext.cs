using Microsoft.EntityFrameworkCore;
using PrimeStone.RAT.Entities;

namespace PrimeStone.RAT.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
