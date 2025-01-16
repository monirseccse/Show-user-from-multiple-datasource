using Assignment.Model.Domain;

namespace Assignment.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User model);
        Task UpdateAsync(int id, User model);
        Task DeleteAsync(int id);
    }
}
