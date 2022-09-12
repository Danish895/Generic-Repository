using GenericRepository.DataAccessLayer.ApplicationDbContext;
using GenericRepository.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericRepository.DataAccessLayer.Repository
{
    public class GenericRepository <T> : IGenericRepository <T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _entities;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsyncAll()
        {
            return (IEnumerable<T>)await _entities.ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
                return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AddAsyncStudent(Student student)
        {
            var booleanResult = await _context.AddAsync(student);
            _context.SaveChanges();
            return true;
        }
    }
}
