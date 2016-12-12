using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.AccountPolicy;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.DAL.Enums;

namespace EventManager.BL.Services.UserAccounts
{
    public interface IAppUserService
    {

        /// <summary>
        /// Registers user account.
        /// </summary>
        /// <param name="userRegistration">user data</param>
        /// <param name="role">role in system</param>
        /// <returns>user id</returns>
        Guid RegisterUserAccount(UserRegistrationDTO userRegistration, string role = Claims.Member);

        /// <summary>
        /// Authenticates user with given username and password
        /// </summary>
        /// <param name="loginDto">user login details</param>
        /// <returns>ID of the authenticated user</returns>
        Guid AuthenticateUser(UserLoginDTO loginDto);

        /// <summary>
        /// Updates user role.
        /// </summary>
        /// <param name="userAccountId">user id</param>
        /// <param name="role">new role</param>
        void UpdateUserRole(Guid userAccountId, string role);
    }
}
