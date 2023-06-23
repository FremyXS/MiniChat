using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MiniChat.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ChatDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<ChatDbContext>();

            return services;
        }
    }
}
