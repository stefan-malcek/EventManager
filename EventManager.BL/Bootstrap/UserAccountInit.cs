using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.Facades;
using EventManager.BL.Services.UserAccounts;
using EventManager.BL.Services.Users;

namespace EventManager.BL.Bootstrap
{
    public static class UserAccountInit
    {
        /// <summary>
        /// Initializes DB with various user accounts and promo codes
        /// </summary>
        /// <param name="container"></param>
        public static void InitializeUserAccounts(IWindsorContainer container)
        {
            CreateUsers(container);
        }

        /// <summary>
        /// Creates users (admin and customers) for demo eshop
        /// </summary>
        /// <param name="container">The windsor container</param>
        private static void CreateUsers(IWindsorContainer container)
        {
            var userAccountManagementService = container.Resolve<IAppUserService>();
            var userFacade = container.Resolve<UserFacade>();
            bool success;

            userAccountManagementService.RegisterUserAccount(new UserRegistrationDTO
            {
                Birthday = new DateTime(1980, 1, 1),
                Email = "admin@eventmabager.com",
                FirstName = "EventManager",
                LastName = "Administrator",
                Password = "123456"
            }, true);

            userFacade.RegisterCustomer(new UserRegistrationDTO
            {
                Birthday = new DateTime(1990, 9, 20),
                Email = "hadodrakp@atlas.sk",
                FirstName = "Eugen",
                LastName = "Hadodrak",
                Password = "SecretPa$$" // same for the email account
            }, out success);

            userFacade.RegisterCustomer(new UserRegistrationDTO
            {
                Birthday = new DateTime(1985, 11, 6),
                Email = "drakohad@atlas.sk", // password: SecretPa$$
                FirstName = "Jan",
                LastName = "Drakohad",
                Password = "SecretPa$$" // same for the email account
            }, out success);
        }

        ///// <summary>
        ///// Creates promo codes for demo eshop customers
        ///// </summary>
        ///// <param name="container">The windsor container</param>
        //private static void CreatePromoCodes(IWindsorContainer container)
        //{
        //    // create sample promo codes for customers
        //    var promoteService = container.Resolve<IPromoteService>();
        //    promoteService.CreateCoupon(1, "TGRV27DX");
        //    promoteService.CreateCoupon(2, "WQ3U9J42");
        //}
    }
}
