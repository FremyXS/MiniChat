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
                options.UseNpgsql("Server=localhost;Port=6789;Database=MiniChatDataBase;Username=postgres;Password=123456",
                    options => options.UseNodaTime());
            });

            services.AddScoped<ChatDbContext>();

            return services;
        }
    }
}
