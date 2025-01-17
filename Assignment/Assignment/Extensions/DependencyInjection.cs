using Assignment.DbContexts;
using Assignment.Profiles;
using Assignment.Repositories;
using Assignment.Repositories.NoSqlRepository;
using Assignment.Repositories.RelationalRepository;
using Assignment.SeedData;
using Assignment.Services;
using AutoMapper;

namespace Assignment.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbSeeder>();
            services.AddScoped<RDBMSRepository>();
            services.AddScoped(typeof(MongoRepository));
            services.AddScoped(typeof(JsonRepository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(RepositoryFactory));
            return services;
        }
    }
}
