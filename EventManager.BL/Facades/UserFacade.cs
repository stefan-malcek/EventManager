using System;
using System.Collections.Generic;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.DTOs.Users;
using EventManager.BL.Services.UserAccounts;
using EventManager.BL.Services.Users;

namespace EventManager.BL.Facades
{
    public class UserFacade
    {
        private readonly IUserService _userService;
        private readonly IAppUserService _appUserService;

        public UserFacade(IUserService userService, IAppUserService appUserService)
        {
            _userService = userService;
            _appUserService = appUserService;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="userDto">user</param>
        //public void CreateUser(UserCreateDTO userDto)
        //{
        //    _userService.CreateUser(userDto);
        //}

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

        /// <summary>
        /// Performs customer registration
        /// </summary>
        /// <param name="registrationDto">Customer registration details</param>
        /// <param name="success">argument that tells whether the registration was successful</param>
        /// <returns>Registered customer account ID</returns>
        public Guid RegisterUser(UserRegistrationDTO registrationDto, out bool success)
        {
            if (_userService.GetUserAccortingToEmail(registrationDto.Email) != null)
            {
                success = false;
                return new Guid();
            }
            var accountId = _appUserService.RegisterUserAccount(registrationDto);
         _userService.CreateUser(registrationDto, accountId);
            success = true;
            return accountId;
        }

        /// <summary>
        /// Authenticates user with given username and password
        /// </summary>
        /// <param name="loginDto">user login details</param>
        /// <returns>ID of the authenticated user</returns>
        public Guid AuthenticateUser(UserLoginDTO loginDto)
        {
            return _appUserService.AuthenticateUser(loginDto);
        }
    }
}
