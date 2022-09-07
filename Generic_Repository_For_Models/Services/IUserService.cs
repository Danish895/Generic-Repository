using Generic_Repository_For_Models.Model;
using System.Linq.Expressions;

namespace Generic_Repository_For_Models.Services
{
    public interface IUserService <T>  where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllUser();
        Task<T> findByName(Expression<Func<T, bool>> predicate);
    }
}
