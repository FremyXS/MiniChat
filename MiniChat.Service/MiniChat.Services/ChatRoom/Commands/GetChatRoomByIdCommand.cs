using Microsoft.EntityFrameworkCore;
using MiniChat.Database;
using MiniChat.Service.ChatRoom.Common;

namespace MiniChat.Service.ChatRoom.Commands
{
    public class GetChatRoomByIdCommand : IGetChatRoomByIdCommand
    {
        private readonly ChatDbContext _chatDbContext;

        public GetChatRoomByIdCommand(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }

        public async Task<Database.Entity.ChatRoom> Invoke(long id)
        {
            var chat = await _chatDbContext.ChatRooms
                .Include(el => el.Users)
                .Include(el => el.Messages)
                .FirstOrDefaultAsync(el => el.Id == id);

            if (chat == null)
            {
                throw new Exception($"Chat room not found with id: {id}");
            }

            return chat;
        }
    }
}
