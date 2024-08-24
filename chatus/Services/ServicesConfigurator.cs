﻿using chatus.API.Contracts;

namespace chatus.API.Services
{
    public static class ServicesConfigurator
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
