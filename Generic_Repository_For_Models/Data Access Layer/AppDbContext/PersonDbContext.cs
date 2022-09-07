using Generic_Repository_For_Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Generic_Repository_For_Models.Data_Access_Layer.AppDbContext
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options) { }
        
        public DbSet<Student> Students { get; set; }    
        public DbSet<Employee> Employees { get; set; }    

    }
}
