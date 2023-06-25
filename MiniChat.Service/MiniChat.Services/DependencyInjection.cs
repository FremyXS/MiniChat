using Microsoft.Extensions.DependencyInjection;
using MiniChat.Service.Commands;
using MiniChat.Service.Commands.Interface;
using MiniChat.Service.Service;
using MiniChat.Service.Service.Interface;
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

            services.AddTransient<IGetChatRoomsByUserIdCommand, GetChatRoomsByUserIdCommand>();
            services.AddTransient<IGetChatRoomByIdCommand, GetChatRoomByIdCommand>();
            services.AddTransient<ICreateChatRoomCommand, CreateChatRoomCommand>();
            services.AddTransient<IUpdateChatRoomCommand, UpdateChatRoomCommand>();
            services.AddTransient<IDeleteChatRoom, DeleteChatRoom>();
            services.AddTransient<IChatRoomService, ChatRoomService>();

            return services;
        }
    }
}