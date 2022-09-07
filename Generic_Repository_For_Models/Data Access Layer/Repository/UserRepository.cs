using Generic_Repository_For_Models.Data_Access_Layer.AppDbContext;
using Generic_Repository_For_Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Generic_Repository_For_Models.Data_Access_Layer.Repository
{
    public class UserRepository <T> : IUserRepository <T> where T : BaseEntity
    {
        private readonly PersonDbContext _context;
        private DbSet<T> _entities;
        public UserRepository(PersonDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return (IEnumerable<T>)await _entities.ToListAsync();

        }
        
    }
}
