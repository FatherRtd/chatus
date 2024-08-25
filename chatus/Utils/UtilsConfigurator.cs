using chatus.API.Entities.Repositories;

namespace chatus.API.Utils
{
    public static class UtilsConfigurator
    {
        public static IServiceCollection AddApplicationUtils(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
