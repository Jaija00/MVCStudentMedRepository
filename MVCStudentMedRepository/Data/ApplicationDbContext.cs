using Microsoft.EntityFrameworkCore;
using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
