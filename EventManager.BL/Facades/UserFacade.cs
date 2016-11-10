using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Services.Users;

namespace EventManager.BL.Facades
{
    public class UserFacade
    {
        private readonly IUserService _userService;

        public UserFacade(IUserService userService)
        {
            _userService = userService;
        }

        public void CreateUser(UserDTO userDto)
        {
            _userService.CreateUser(userDto);
        }

        public void UpdateUser(UserDTO userDto)
        {
            _userService.UpdateUser(userDto);
        }

        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }

        public IEnumerable<UserDTO> ListUsers(UserFilter filter)
        {
            return _userService.ListUsers(filter);
        }
    }
}
