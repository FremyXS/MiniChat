using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniChat.Service.Authentication;
using MiniChat.Service.Authentication.Commands;
using MiniChat.Service.Authentication.Common;
using MiniChat.Service.ChatRoom;
using MiniChat.Service.ChatRoom.Commands;
using MiniChat.Service.ChatRoom.Common;
using MiniChat.Service.Message;
using MiniChat.Service.Message.Commands;
using MiniChat.Service.Message.Common;
using MiniChat.Service.User;
using MiniChat.Service.User.Commands;
using MiniChat.Service.User.Common;

namespace MiniChat.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IGetUserByIdCommand, GetUserByIdCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IGetUsersCommand, GetUsersCommand>();
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IGetUsersByIdArrayCommand, GetUsersByIdArrayCommand>();
            services.AddTransient<IGetChatRoomsByUserIdCommand, GetChatRoomsByUserIdCommand>();
            services.AddTransient<IGetChatRoomByIdCommand, GetChatRoomByIdCommand>();
            services.AddTransient<ICreateChatRoomCommand, CreateChatRoomCommand>();
            services.AddTransient<IUpdateChatRoomCommand, UpdateChatRoomCommand>();
            services.AddTransient<IDeleteChatRoomCommand, DeleteChatRoomCommand>();
            services.AddTransient<IChatRoomService, ChatRoomService>();

            services.AddTransient<IGetMessageById, GetMessageById>();
            services.AddTransient<IGetMessagesByChatIdCommand, GetMessagesByChatIdCommand>();
            services.AddTransient<ICreateMessageCommand, CreateMessageCommand>();
            services.AddTransient<IUpdateMessageCommand, UpdateMessageCommand>();
            services.AddTransient<IDeleteMessageCommand, DeleteMessageCommand>();
            services.AddTransient<IMessageService, MessageService>();

            services.AddJwtAuth(configuration);

            return services;
        }
    }
}