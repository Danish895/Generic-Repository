using GenericRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.DataAccessLayer.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        
        public DbSet<Student> Students { get; set; }    
        public DbSet<Employee> Employees { get; set; }    
    }
}
