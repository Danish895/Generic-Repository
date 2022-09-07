

using Generic_Repository_For_Models.Data_Access_Layer.Repository;
using Generic_Repository_For_Models.Model;
using System.Linq.Expressions;

namespace Generic_Repository_For_Models.Services
{
    public class UserService<T> : IUserService<T> where T : BaseEntity
    {
        private IUserRepository<T> _UserRepository;

        public UserService(IUserRepository<T> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<T> findByName(Expression<Func<T, bool>> predicate)
        {
            var detail = await _UserRepository.FindByConditionAsync(predicate);
            return detail;
        }

        public async Task<IEnumerable<T>> GetAllUser()
        {
            var detail = await _UserRepository.GetAll();
            return detail;
        }


    }
}
