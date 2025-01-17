using Assignment.Model.Domain;
using Assignment.Repositories.RelationalRepository;

namespace Assignment.Repositories
{
    public class RepositoryFactory<T> where T : BaseEntity
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryFactory(IServiceProvider serviceProvider, 
            IHttpContextAccessor httpContextAccessor)
        {
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public IRepository<T> GetRepository()
        {
            var headers = _httpContextAccessor.HttpContext?.Request.Headers;
            headers.TryGetValue("Datasource", out var datasource);
            return datasource.ToString().ToLower() switch
            {
                "sql" => _serviceProvider.GetRequiredService<RDBMSRepository<T>>(),
                "json" => _serviceProvider.GetRequiredService<JsonRepository<T>>(),
                _ => _serviceProvider.GetRequiredService<MongoRepository<T>>()
            };
        }
    }
}
