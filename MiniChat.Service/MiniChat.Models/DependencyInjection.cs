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
            services.AddScoped<ChatRoomCreateRequestValidator>();
            services.AddScoped<ChatRoomUpdateRequestValidator>();
            services.AddScoped<AccountAuthenticateRequestValidator>();
            services.AddScoped<AccountCreateRequestValidator>();

            return services;
        }
    }
}
