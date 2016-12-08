using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.DAL.Enums;

namespace EventManager.BL.Services.UserAccounts
{
    public interface IAppUserService
    {
        /// <summary>
        /// Registers user (typically with default claims)
        /// </summary>
        /// <param name="userRegistration">User registration details</param>
        /// <param name="createAdmin">Grant user admin rights</param>
        /// <returns>ID of registered user</returns>
        Guid RegisterUserAccount(UserRegistrationDTO userRegistration, UserRole role = UserRole.Member);

        /// <summary>
        /// Authenticates user with given username and password
        /// </summary>
        /// <param name="loginDto">user login details</param>
        /// <returns>ID of the authenticated user</returns>
        Guid AuthenticateUser(UserLoginDTO loginDto);

        void UpdateUserRole(Guid userAccountId, string role);
    }
}
