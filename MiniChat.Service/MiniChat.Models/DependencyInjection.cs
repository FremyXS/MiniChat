using Microsoft.Extensions.DependencyInjection;
using MiniChat.Models.Validators;

namespace MiniChat.Models
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddModels(this IServiceCollection services)
        {
            services.AddScoped<UserCreateRequestValidator>();
            services.AddScoped<UserUpdateRequestValidator>();

            return services;
        }
    }
}
