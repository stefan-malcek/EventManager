using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using EventManager.AccountPolicy;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.Facades;
using EventManager.BL.Services.UserAccounts;
using EventManager.BL.Services.Users;
using EventManager.DAL.Entities;
using EventManager.DAL.Enums;

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
            CreateEvents(container);
        }

        private static void CreateEvents(IWindsorContainer container)
        {
            var eventFacade = container.Resolve<EventFacade>();
            var userFacade = container.Resolve<UserFacade>();
            var registrationFacade = container.Resolve<RegistrationFacade>();

            var addressId = eventFacade.ListAddresses(new AddressFilter()).First().Id;
            var users = userFacade.ListUsers(new UserFilter {Role = Claims.Organizer});
            var organizerId = users.First().Id;

            eventFacade.CreateEvent(new EventDTO
            {
                Title = "Entity Framework basics",
                Description = "Entity Framework (EF) is an object-relational mapper that enables " +
                              ".NET developers to work with relational data using domain-specific " +
                              "objects. It eliminates the need for most of the data-access code that " +
                              "developers usually need to write.",
                Lecturer = "Pavel Novák",
                Date = new DateTime(2016, 11, 1),
                Start = new TimeSpan(14, 0, 0),
                End = new TimeSpan(16, 0, 0),
                UserId = organizerId,
                AddressId = addressId
            });

            var eventId = eventFacade.ListEvents(new EventFilter()).ResultPageData.First().Id;

            eventFacade.CreateReview(new EventReviewCreateDTO
            {
                EventId = eventId,
                Rating = 5,
                Review = "Very good code examples."
            });

            eventFacade.CreateReview(new EventReviewCreateDTO
            {
                EventId = eventId,
                Rating = 3,
                Author = "Not cool guy",
                Review = "I missed something there. Also i need to test my UI so this post will be longer. What should I say. " +
                                 "Maybe food was not very good there. I had one adventure day after. Ok, well done. I think it is enough."
            });

            eventFacade.CreateReview(new EventReviewCreateDTO
            {
                EventId = eventId,
                Rating = 5,
                Author = "Cool guy",
                Review = "It was so awesome."
            });

            eventFacade.CreateEvent(new EventDTO
            {
                Title = "Entity Framework advanced",
                Description = "Some cool examples of advanced topics in Entity framework.",
                Lecturer = "Jan Adamec",
                Date = new DateTime(2016, 12, 22),
                Start = new TimeSpan(16, 30, 0),
                End = new TimeSpan(19, 0, 0),
                UserId = organizerId,
                AddressId = addressId,
                Capacity = 10,
                Fee = 20,
            });

            var eventId2 = eventFacade.ListEvents(new EventFilter { Date = new DateTime(2016, 12, 22) })
                .ResultPageData.First().Id;

            var memberIds = userFacade.ListUsers(new UserFilter { Role = Claims.Member }).Select(s => s.Id);

            foreach (var memberId in memberIds)
            {
                registrationFacade.Register(new RegistrationCreateDTO { EventId = eventId2, UserId = memberId });
            }


        }

        /// <summary>
        /// Creates users (admin and customers) for demo eshop
        /// </summary>
        /// <param name="container">The windsor container</param>
        private static void CreateUsers(IWindsorContainer container)
        {
            var userAccountManagementService = container.Resolve<IAppUserService>();
            var userService = container.Resolve<IUserService>();
            var userFacade = container.Resolve<UserFacade>();
            bool success;

            var adminDTO = new UserRegistrationDTO
            {
                Birthday = new DateTime(1980, 1, 1),
                Email = "admin@eventmanager.com",
                FirstName = "EventManager",
                LastName = "Administrator",
                Password = "123456"
            };

            var adminGuid = userAccountManagementService.RegisterUserAccount(adminDTO, UserRole.Administrator);
            userService.CreateUser(adminDTO, adminGuid);

            var organizerDTO = new UserRegistrationDTO
            {
                Birthday = new DateTime(1991, 5, 6),
                Email = "petrvelky@eventmanager.com",
                FirstName = "Petr",
                LastName = "Velky",
                Password = "123456"
            };

            var organizerGUID = userAccountManagementService.RegisterUserAccount(organizerDTO, UserRole.Organizer);
            userService.CreateUser(organizerDTO, organizerGUID);


            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1990, 3, 12),
                Email = "eugenmaly@atlas.sk",
                FirstName = "Eugen",
                LastName = "Malý",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1985, 11, 6),
                Email = "jannovotny@seznam.cz", // password: SecretPa$$
                FirstName = "Jan",
                LastName = "Novotny",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1994, 12, 18),
                Email = "stefanmalcek@atlas.sk", // password: SecretPa$$
                FirstName = "Štefan",
                LastName = "Malček",
                Password = "123456" // same for the email account
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1985, 11, 6),
                Email = "elenavysoka@atlas.sk", // password: SecretPa$$
                FirstName = "Elena",
                LastName = "Vysoká",
                Password = "123456" // same for the email account
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
