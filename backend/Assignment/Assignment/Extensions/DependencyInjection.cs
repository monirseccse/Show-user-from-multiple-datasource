using Assignment.DbContexts;
using Assignment.Profiles;
using Assignment.Repositories;
using Assignment.Repositories.Factory;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(RepositoryFactory));
            services.AddScoped<RDBMSRoleRepository>();
            services.AddScoped(typeof(MongoRoleRepository));
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped(typeof(RoleRepositoryFactory));
            return services;
        }
    }
}
