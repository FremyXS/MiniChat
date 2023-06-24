using MiniChat.Database.Entity;
using MiniChat.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Services.Service.Interface
{
    public interface IUserService
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetUserById(long userId);
        Task<int> CreateUser(UserCreateRequest userRequest);
        Task<int> UpdateUser(long userId, UserUpdateRequest userUpdateRequest);
        Task<int> DeleteUser(long userId);
    }
}
