using Assignment.Model.Domain;

namespace Assignment.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRoles();
    }
}
