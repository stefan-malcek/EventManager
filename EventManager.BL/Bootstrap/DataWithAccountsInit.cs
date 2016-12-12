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
    public static class DataWithAccountsInit
    {
        public static void InitializeUserAccounts(IWindsorContainer container)
        {
            CreateUsers(container);
            SeedDb();
        }

        private static void SeedDb()
        {
            var context = new EventManagerDbContext();

            var organizer = context.Users.Include(i => i.Account.ClaimCollection)
                .FirstOrDefault(w => w.Account.ClaimCollection.Any(a => Equals(a.Value, Claims.Organizer)));
            var members = context.Users.Where(w => w.Account.ClaimCollection.Any(a => Equals(a.Value, Claims.Member)))
               .ToList();
            var addresses = context.Addresses.ToList();


            context.Events.Add(new Event
            {
                Address = addresses.First(),
                Title = "Effective C# Unit Testing for Enterprise Applications",
                Description = "Creating effective C# unit tests for enterprise applications requires thoughtful consideration " +
                              "so that your test suite doesn't become burdensome from being rote, brittle, and untrustworthy. In " +
                              "this course, Effective C# Unit Testing for Enterprise Applications, you'll learn techniques to create" +
                              " unit tests that are readable, risk-driven, and resilient to refactoring. You'll learn how to create " +
                              "maintainable unit tests by examining three pillars of effective unit tests. First, unit tests need to " +
                              "be clear and simple and emphasize readability. Second, unit tests should provide the highest value by " +
                              "focusing on validating your most important and complicated code. Lastly, you're test must stay flexible " +
                              "by knowing as few details about your production code as possible. By the end of this course, you'll see" +
                              " a new perspective on unit testing that emphasizes thoughtful unit testing.",
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
                Title = "Android Fundamentals: Accessibility",
                Description = "Many users have physical limitations that may make seeing the device display or interacting with the " +
                              "touchscreen difficult. Android provides a number of accessibility features and services and this course, " +
                              "Android Fundamentals: Accessibility, will serve as your guide to including these features in your apps." +
                              " You'll start with an introduction to the goals of accessibility and how Android handles accessibility." +
                              " Then, you'll get started making apps accessible by incorporating support for non-touch navigation and " +
                              "view descriptions, as well as seeing how to design and create apps that provide a single high-quality " +
                              "experience that works equally well for users with or without accessibility needs. You'll also get to see " +
                              "how to add some important accessibility features, such as Talkback support and d-pad navigation, to your " +
                              "custom views. Finally, you will go over the important relationship between testing and accessibility. By " +
                              "the end of this course, you'll be better able to build apps in such a way that they will be accessible to all users.",
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
                Title = "Web Development with Django and AngularJS",
                Description = "Take a journey to learn full-slack web development in this course. In this course, Web Development" +
                              " with Django and AngularJS, you'll learn how to get the best of both worlds with web development in " +
                              "Django and AngularJS. We will use the power of AngularJS to create a rich interactive user experience, " +
                              "and the awesomeness that is Django to write our server-side code, including REST and persistence to a database." +
                              " First, you'll discover how to create a basic web application with Django. Next, you'll explore using AngularJS" +
                              " to add an interactive front-end. Finally, you'll learn how to use REST and AJAX to pass data between" +
                              " the front-end JavaScript and back-end Python code. By the end of this course, you'll know the basics " +
                              "of both Django and AngularJS, and how to combine them to create a fully interactive web application.",
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
                Title = "Building an MVVM-based Architecture for Xamarin Mobile Apps",
                Description = "People spend more time than ever on their mobile phones using apps. Building great apps is" +
                              " big business. But, you want to build them right the first time. In this course, Building an" +
                              " MVVM-based Architecture for Xamarin Mobile Apps, you will learn how to create a reusable, " +
                              "enterprise-ready architecture for Xamarin mobile apps for both iOS and Android, based on the principles " +
                              "of the MVVM pattern. First, you'll learn how to build a reusable architecture and see how you can apply" +
                              " MVVM to Xamarin. Next, you'll learn all about the MVVMCross framework. Finally, you'll learn how to" +
                              "write unit tests to test out your code. By the end of this course, you'll know how you can build your " +
                              "Xamarin mobile apps the right way, using an architecture that is built to create maintainable and testable apps.",
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
                Title = "Java EE 7 Fundamentals",
                Description = "Java EE 7 has established itself as the preeminent Java stack for web and back-end developers. " +
                              "This code-focused course shows how to build a complete application covering most of the Java EE 7" +
                              " specifications. You'll learn about how the Java EE platform has progressed through its history to " +
                              "the modern platform it is today, the foundations of building a web application in Java EE, and how to " +
                              "interoperate Java EE applications with external services. You'll also learn about architectural best" +
                              " practices when building a Java EE application. By the end of this course, you'll have a solid foundational" +
                              " for building Java EE applications of your own.",
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
                Title = "Design Patterns with Python",
                Description = "At the core of professional programming practice is a thorough knowledge of software design" +
                              " patterns. In this course, Design Patterns with Python, you will learn eight classic patterns" +
                              " and how to implement them in Python. You will learn how to recognize problems that are solvable" +
                              " using design patterns, how to implement them professionally, and how they can be used to make " +
                              "your programs easier to write, easier to read, and easier to maintain. When you're finished with" +
                              " this course, you will have a better understanding of the elements of reusable object-oriented " +
                              "software design, which will help you as you move beyond simple scripts to complex systems built in " +
                              "Python. Software required: A Python interpreter in the 2.7 series or the 3.5 series and a Python-aware" +
                              " integrated development environment (IDE).",
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
            context.Dispose();
        }

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

            var adminGuid = userAccountManagementService.RegisterUserAccount(adminDTO, Claims.Admin);
            userService.CreateUser(adminDTO, adminGuid);

            var organizerDTO = new UserRegistrationDTO
            {
                Birthday = new DateTime(1991, 5, 6),
                Email = "adammaruska@mail.com",
                FirstName = "Adam",
                LastName = "Maruška",
                Password = "123456"
            };

            var organizerGUID = userAccountManagementService.RegisterUserAccount(organizerDTO, Claims.Organizer);
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
    }
}
