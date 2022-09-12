

using GenericRepository.DataAccessLayer.Repository;
using GenericRepository.Model;
using System.Linq.Expressions;

namespace GenericRepository.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private IGenericRepository<T> _userRepository;

        public GenericService(IGenericRepository<T> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddAsyncStudent(Student student)
        {
            bool success = await _userRepository.AddAsyncStudent(student);
            return success;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var detail = await _userRepository.FirstOrDefaultAsync(predicate);
            return detail;
        }

        public async Task<IEnumerable<T>> GetAsyncAll()
        {
            var detail = await _userRepository.GetAsyncAll();
            return detail;
        }


    }
}
