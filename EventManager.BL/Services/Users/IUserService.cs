using System.Collections.Generic;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Users;

namespace EventManager.BL.Services.Users
{
    public interface IUserService
    {
        void CreateUser(UserCreateDTO userDto);

        void UpdateUser(UserDTO userDto);

        void DeleteUser(int userId);

        UserDTO GetUser(int userId);

        UserDTO GetUserAccortingToEmail(string email);

        IEnumerable<UserDTO> ListUsers(UserFilter filter);
    }
}
