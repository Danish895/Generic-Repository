using GenericRepository.Model;
using System.Linq.Expressions;

namespace GenericRepository.Services
{
    public interface IGenericService <T>  where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsyncAll();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<bool> AddAsyncStudent(Student student);
    }
}
