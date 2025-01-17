using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using System.Linq.Expressions;

namespace Assignment.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> filter = null, int skip = 0, int take = 10);
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(int id);
        Task<long> CountAsync(Expression<Func<User, bool>> filter = null);
    }
}
