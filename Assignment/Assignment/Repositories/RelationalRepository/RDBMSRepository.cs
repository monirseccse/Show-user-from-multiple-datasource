using Assignment.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repositories.RelationalRepository
{
    public class RDBMSRepository<T> : IRepository<T> where T : class
    {
        private readonly RDBMSDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RDBMSRepository(RDBMSDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
