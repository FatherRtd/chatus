using chatus.API.Contracts;
using chatus.API.Services;

namespace chatus.API.Entities.Repositories
{
    public static class RepositoriesConfigurator
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
