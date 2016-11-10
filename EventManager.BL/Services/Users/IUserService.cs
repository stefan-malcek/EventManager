using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Filters;

namespace EventManager.BL.Services.Users
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDto);

        void UpdateUser(UserDTO userDto);

        void DeleteUser(int userId);

        UserDTO GetUser(int userId);

        IEnumerable<UserDTO> ListUsers(UserFilter filter);
    }
}
