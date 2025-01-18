using Assignment.DbContexts;
using Assignment.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repositories.RelationalRepository
{
    public class RDBMSRoleRepository : IRoleRepository
    {
        private readonly RDBMSDbContext _context;
        private readonly DbSet<Role> _dbSet;

        public RDBMSRoleRepository(RDBMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = _context.Set<Role>().ToList();
            return roles;
        }
    }
}
