using Generic_Repository_For_Models.Model;

namespace Generic_Repository_For_Models.Services
{
    public interface IUserService <T>  where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllUser();
    }
}
