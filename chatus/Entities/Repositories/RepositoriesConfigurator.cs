namespace chatus.API.Entities.Repositories
{
    public static class RepositoriesConfigurator
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();

            return services;
        }
    }
}
