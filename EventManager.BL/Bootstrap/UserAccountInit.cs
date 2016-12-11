using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using EventManager.DAL;
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
            SeedDb();
            //CreateEvents(container);
        }

        private static void SeedDb()
        {
            var context = new EventManagerDbContext();

            var organizer = context.Users.Include(i => i.Account.ClaimCollection).FirstOrDefault(w => w.Account.ClaimCollection.Any(a => Equals(a.Value, Claims.Organizer)));
            var members = context.Users.Where(w => w.Account.ClaimCollection.Any(a => Equals(a.Value, Claims.Member)))
               .ToList();
            var addresses = context.Addresses.ToList();


            context.Events.Add(new Event
            {
                Address = addresses.First(),
                Title = "Entity Framework basics",
                Description = "Just basic stuff.\n",
                Lecturer = "Pavel Novák",
                Date = new DateTime(2016, 11, 1),
                Start = new TimeSpan(14, 0, 0),
                End = new TimeSpan(16, 0, 0),
                EventOrganizer = new EventOrganizer { User = organizer },
                EventReviews = new List<EventReview>
                {
                    new EventReview
                    {
                        Rating = 5,
                        Review = "Very good code examples."
                    },
                    new EventReview
                    {
                        Rating = 3,
                        Author = "Not cool guy",
                        Review = "I missed something there. Also i need to test my UI so this post will be longer. What should I say. " +
                                 "Maybe food was not very good there. I had one adventure day after. Ok, well done. I think it is enough."
                    },
                    new EventReview
                    {
                        Rating = 5,
                        Author = "Cool guy",
                        Review = "It was so awesome."
                    }
                },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(0).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(1).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(2).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(3).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                        User = members.Skip(4).FirstOrDefault()
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = addresses.First(),
                Title = "Entity Framework advanced",
                Description = "Some cool examples of advanced topics in Entity framework.\n",
                Lecturer = "Jan Adamec",
                Date = new DateTime(2016, 12, 23),
                Start = new TimeSpan(16, 30, 0),
                End = new TimeSpan(19, 0, 0),
                EventOrganizer = new EventOrganizer { User = organizer },
                Capacity = 10,
                Fee = 20,
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(0).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Unpaid,
                          User = members.Skip(2).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(4).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(6).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Unpaid,
                        User = members.Skip(7).FirstOrDefault()
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = addresses.Skip(1).First(),
                Title = "Windows 10",
                Description = "Introduction to new operating system Windows 10. We will look on basic functionality and also some new cool features.",
                Lecturer = "Fernando Torrez",
                Date = new DateTime(2017, 1, 5),
                Start = new TimeSpan(17, 30, 0),
                End = new TimeSpan(20, 0, 0),
                EventOrganizer = new EventOrganizer { User = organizer },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(0).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(1).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                         User = members.Skip(2).FirstOrDefault()
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = addresses.First(),
                Title = "ASP.NET MVC",
                Description = "smt",
                Lecturer = "Fernando Torrez",
                Date = new DateTime(2017, 1, 20),
                Start = new TimeSpan(18, 30, 0),
                End = new TimeSpan(21, 0, 0),
                EventOrganizer = new EventOrganizer { User = organizer },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(3).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(5).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(7).FirstOrDefault()
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = addresses.Skip(1).First(),
                Title = "Unit testing",
                Description = "smt",
                Lecturer = "Jiří Novotný",
                Date = new DateTime(2016, 9, 28),
                Start = new TimeSpan(15, 30, 0),
                End = new TimeSpan(17, 0, 0),
                EventOrganizer = new EventOrganizer { User = organizer },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(4).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(9).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(6).FirstOrDefault()
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = addresses.Skip(1).First(),
                Title = ".NET Core",
                Description = "smt",
                Lecturer = "Jiří Novotný",
                Date = new DateTime(2016, 11, 28),
                Start = new TimeSpan(14, 00, 0),
                End = new TimeSpan(17, 0, 0),
                EventOrganizer = new EventOrganizer { User = organizer },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                         User = members.Skip(4).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = members.Skip(8).FirstOrDefault()
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                         User = members.Skip(10).FirstOrDefault()
                    }
                }
            });

            context.SaveChanges();
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

            var eventId2 = eventFacade.ListEvents(new EventFilter { Title = "Entity Framework advanced" })
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
                Birthday = new DateTime(1980, 11, 1),
                Email = "admin@eventmanager.com",
                FirstName = "Řehoř",
                LastName = "Bartoš",
                Password = "123456"
            };

            var adminGuid = userAccountManagementService.RegisterUserAccount(adminDTO, UserRole.Administrator);
            userService.CreateUser(adminDTO, adminGuid);

            var organizerDTO = new UserRegistrationDTO
            {
                Birthday = new DateTime(1991, 5, 6),
                Email = "adammaruska@mail.com",
                FirstName = "Adam",
                LastName = "Maruška",
                Password = "123456"
            };

            var organizerGUID = userAccountManagementService.RegisterUserAccount(organizerDTO, UserRole.Organizer);
            userService.CreateUser(organizerDTO, organizerGUID);


            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1990, 3, 12),
                Email = "boleslavpechacek@mail.com",
                FirstName = "Boleslav",
                LastName = "Pecháček",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1985, 11, 6),
                Email = "zdenkanovakova@seznam.cz",
                FirstName = "Zdeňka",
                LastName = "Novákova",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1994, 12, 18),
                Email = "emilhruby@atlas.sk",
                FirstName = "Emil",
                LastName = "Hruby",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1985, 11, 6),
                Email = "kajaslezak@mail.com",
                FirstName = "Kája",
                LastName = "Slezák",
                Password = "123456"
            }, out success);


            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1997, 3, 13),
                Email = "bohdanhavlicek@mail.com",
                FirstName = "Bohdan",
                LastName = "Havlíček",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1975, 10, 8),
                Email = "lubomirhavlicek@seznam.cz",
                FirstName = "Lubomír",
                LastName = "Havlíček",
                Password = "Tesar"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1980, 4, 16),
                Email = "renedoubek@mail.com",
                FirstName = "René",
                LastName = "Doubek",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1989, 11,26),
                Email = "katerinastrnadova@atlas.sk",
                FirstName = "Kateřina",
                LastName = "Strnadova",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1982, 1, 14),
                Email = "vojtechrybar@mail.com",
                FirstName = "Vojtěch",
                LastName = "Rybář",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1990, 11, 23),
                Email = "edvardkudrna@atlas.sk",
                FirstName = "Edvard",
                LastName = "Kudrna",
                Password = "123456"
            }, out success);

            userFacade.RegisterUser(new UserRegistrationDTO
            {
                Birthday = new DateTime(1985, 7, 9),
                Email = "janadolezalova@seznam.cz",
                FirstName = "Jana",
                LastName = "Doležalova",
                Password = "123456"
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
