using Assignment.DbContexts;
using Assignment.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignment.Repositories.RelationalRepository
{
    public class RDBMSRepository : IRepository 
    {
        private readonly RDBMSDbContext _context;
        private readonly DbSet<User> _dbSet;

        public RDBMSRepository(RDBMSDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> filter = null, int skip = 0, int take = 10)
        {
            IQueryable<User> query = _context.Set<User>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (skip > 0)
            {
                query = query.Skip(skip);
            }
            if (take > 0)
            {
                query = query.Take(take);
            }
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(User entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
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

        public async Task<long> CountAsync(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> query = _context.Set<User>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AsNoTracking().CountAsync();
        }
    }
}
