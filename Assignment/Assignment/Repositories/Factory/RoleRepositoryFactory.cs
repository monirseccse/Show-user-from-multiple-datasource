using Assignment.Repositories.NoSqlRepository;
using Assignment.Repositories.RelationalRepository;

namespace Assignment.Repositories.Factory
{
    public class RoleRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleRepositoryFactory(IServiceProvider serviceProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public IRoleRepository GetRepository()
        {
            var headers = _httpContextAccessor.HttpContext?.Request.Headers;
            headers.TryGetValue("Datasource", out var datasource);
            return datasource.ToString().ToLower() switch
            {
                "sql" => _serviceProvider.GetRequiredService<RDBMSRoleRepository>(),
                _ => _serviceProvider.GetRequiredService<MongoRoleRepository>()
            };
        }
    }
}
