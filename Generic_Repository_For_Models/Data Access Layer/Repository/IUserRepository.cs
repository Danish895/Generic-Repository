using Generic_Repository_For_Models.Model;

namespace Generic_Repository_For_Models.Data_Access_Layer.Repository
{
    public interface IUserRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
    }
}
