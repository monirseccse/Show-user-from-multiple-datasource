using Assignment.Model.Domain;

namespace Assignment.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
    }
}
