using Assignment.DbContexts;
using Assignment.Repositories;
using Assignment.Repositories.RelationalRepository;
using Assignment.SeedData;
using Assignment.Services;

namespace Assignment.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();
            services.AddSingleton<MongoDbSeeder>();
            services.AddScoped(typeof(RDBMSRepository<>));
            services.AddScoped(typeof(MongoRepository<>));
            services.AddScoped(typeof(JsonRepository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(RepositoryFactory<>));
            return services;
        }
    }
}
