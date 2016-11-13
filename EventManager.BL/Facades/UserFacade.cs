using System.Collections.Generic;
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

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="userDto">user</param>
        public void CreateUser(UserCreateDTO userDto)
        {
            _userService.CreateUser(userDto);
        }

        /// <summary>
        /// Update user data.
        /// </summary>
        /// <param name="userDto">user</param>
        public void UpdateUser(UserDTO userDto)
        {
            _userService.UpdateUser(userDto);
        }

        /// <summary>
        /// Delete user with given userId.
        /// </summary>
        /// <param name="userId">user id</param>
        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }

        /// <summary>
        /// Return user with given userId.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>user</returns>
        public UserDTO GetUser(int userId)
        {
            return _userService.GetUser(userId);
        }

        /// <summary>
        /// Return user with given mail.
        /// </summary>
        /// <param name="mail">mail of user</param>
        /// <returns>user</returns>
        public UserDTO GetUserAccordingToMail(string mail)
        {
            return _userService.GetUserAccortingToEmail(mail);
        }

        /// <summary>
        /// List users with given filter.
        /// </summary>
        /// <param name="filter">user filter</param>
        /// <returns>collection of users</returns>
        public IEnumerable<UserDTO> ListUsers(UserFilter filter)
        {
            return _userService.ListUsers(filter);
        }
    }
}
