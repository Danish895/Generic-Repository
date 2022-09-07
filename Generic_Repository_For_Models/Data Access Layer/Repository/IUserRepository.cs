using Generic_Repository_For_Models.Model;
using System.Linq.Expressions;

namespace Generic_Repository_For_Models.Data_Access_Layer.Repository
{
    public interface IUserRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
