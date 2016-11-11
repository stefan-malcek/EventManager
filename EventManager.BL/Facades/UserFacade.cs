using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Users;
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

        public void CreateUser(UserCreateDTO userDto)
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

        public UserDTO GetUser(int userId)
        {
            return _userService.GetUser(userId);
        }

        public UserDTO GetUserAccordingToMail(string mail)
        {
            return _userService.GetUserAccortingToEmail(mail);
        }

        public IEnumerable<UserDTO> ListUsers(UserFilter filter)
        {
            return _userService.ListUsers(filter);
        }
    }
}
