using Assignment.Model.Domain;
using Assignment.Repositories.NoSqlRepository;
using Assignment.Repositories.RelationalRepository;

namespace Assignment.Repositories.Factory
{
    public class RepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryFactory(IServiceProvider serviceProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public IRepository GetRepository()
        {
            var headers = _httpContextAccessor.HttpContext?.Request.Headers;
            headers.TryGetValue("Datasource", out var datasource);
            return datasource.ToString().ToLower() switch
            {
                "sql" => _serviceProvider.GetRequiredService<RDBMSRepository>(),
                _ => _serviceProvider.GetRequiredService<MongoRepository>()
            };
        }
    }
}
