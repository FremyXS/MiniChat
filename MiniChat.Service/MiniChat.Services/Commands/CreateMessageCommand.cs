using MiniChat.Database;
using MiniChat.Models.Mappers;
using MiniChat.Models.Request;
using MiniChat.Service.Commands.Interface;

namespace MiniChat.Service.Commands
{
    public class CreateMessageCommand: ICreateMessageCommand
    {
        private readonly ChatDbContext _chatDbContext;
        private readonly IGetUserByIdCommand _getUserByIdCommand;
        private readonly IGetChatRoomByIdCommand _getChatRoomByIdCommand;

        public CreateMessageCommand(
            ChatDbContext chatDbContext,
            IGetUserByIdCommand getUserByIdCommand,
            IGetChatRoomByIdCommand getChatRoomByIdCommand)
        {
            _chatDbContext = chatDbContext;
            _getUserByIdCommand = getUserByIdCommand;
            _getChatRoomByIdCommand = getChatRoomByIdCommand;
        }

        public async Task<int> Invoke(MessageCreateRequest messageCreateRequest)
        {
            var user = await _getUserByIdCommand.Invoke(messageCreateRequest.UserId);
            var chat = await _getChatRoomByIdCommand.Invoke(messageCreateRequest.ChatRoomId);

            var chatsId = user.ChatRooms.Select(el => el.Id).ToList();

            if (!chatsId.Contains(chat.Id))
            {
                throw new Exception($"The user is not in the chat room with the id: {chat.Id}");
            }

            var message = messageCreateRequest.ToModel();
            message.ChatRoom = chat;
            message.User = user;
            message = message.SetCreateTime();

            await _chatDbContext.Messages.AddAsync(message);

            var res = await _chatDbContext.SaveChangesAsync();

            return res;
        }
    }
}
