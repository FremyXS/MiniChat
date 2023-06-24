﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniChat.Service.Commands;
using MiniChat.Service.Commands.Interface;
using MiniChat.Services.Service;
using MiniChat.Services.Service.Interface;

namespace MiniChat.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IGetUserByIdCommand, GetUserByIdCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IGetUsersCommand, GetUsersCommand>();
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}