using Assignment.DbContexts;
using Assignment.Repositories;
using Assignment.SeedData;

namespace Assignment.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();
            services.AddSingleton<MongoDbSeeder>();
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            return services;
        }
    }
}
