using Assignment.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DbContexts
{
    public class RDBMSDbContext : DbContext
    {
        public RDBMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
