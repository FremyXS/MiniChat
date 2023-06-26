using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MiniChat.Service.Authentication.Commands;
using MiniChat.Service.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Service.Authentication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();
            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                        // строка, представляющая издателя
                        ValidIssuer = JwtConfiguration.ISSUER,
                        // установка потребителя токена
                        ValidAudience = JwtConfiguration.AUDIENCE,
                        // установка ключа безопасности
                        IssuerSigningKey = JwtConfiguration.GetSymmetricSecurityKey(),
                    };
                });

            services.AddTransient<ICreateJwtTokenCommand, CreateJwtTokenCommand>();
            services.AddTransient<IVerifyPasswordHashCommand, VerifyPasswordHashCommand>();
            services.AddTransient<ICreatePasswordHashCommand, CreatePasswordHashCommand>();
            services.AddTransient<ICreateAccountCommand, CreateAccountCommand>();
            services.AddTransient<IAuthenticateAccount, AuthenticateAccount>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
