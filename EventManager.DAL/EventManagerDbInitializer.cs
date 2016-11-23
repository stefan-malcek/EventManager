using EventManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using EventManager.DAL.Enums;

namespace EventManager.DAL
{
    public class EventManagerDbInitializer : DropCreateDatabaseAlways<EventManagerDbContext>
    {
        public override void InitializeDatabase(EventManagerDbContext context)
        {
            base.InitializeDatabase(context);

            var lorem = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Neque porro quisquam est, qui dolorem ipsum " +
                        "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore " +
                        "et dolore magnam aliquam quaerat voluptatem. Pellentesque sapien. Donec vitae arcu. Morbi imperdiet, mauris ac " +
                        "auctor dictum, nisl ligula egestas nulla, et sollicitudin sem purus in lacus. Fusce nibh. Itaque earum rerum hic " +
                        "tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus" +
                        " asperiores repellat. Nulla non arcu lacinia neque faucibus fringilla. Nullam faucibus mi quis velit. Aliquam erat" +
                        " volutpat. Integer in sapien. Nunc dapibus tortor vel mi dapibus sollicitudin. Nam sed tellus id magna elementum " +
                        "tincidunt. Vivamus luctus egestas leo. Duis viverra diam non justo. Sed ac dolor sit amet purus malesuada congue. " +
                        "Nulla est. In rutrum. Aliquam erat volutpat. Donec ipsum massa, ullamcorper in, auctor et, scelerisque sed, est.";

            var address = new Address
            {
                Building = "Školící místnost společnosti Edhouse s.r.o. (Vědeckotechnický park ICT, budova A, 3. Patro)",
                Street = "Nad Stráněmi",
                StreetNumber = "5656",
                City = "Zlín"
            };

            context.Addresses.Add(address);
            context.Addresses.Add(new Address
            {
                Building = "Technologické centrum Hradec Králové",
                Street = "Piletická",
                StreetNumber = "486 / 19",
                City = "Hradec Králové"
            });

            var user = new User { Role = UserRole.Organizer };
            context.Users.Add(user);
            context.Users.Add(new User {Role = UserRole.Member});

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Entity Framework basics",
                Description = "Just basic stuff.\n" +lorem,
                Lecturer = "Pavel Novák",
                Date = new DateTime(2016, 11, 1),
                Start = new TimeSpan(14, 0, 0),
                End = new TimeSpan(16, 0, 0),
                EventOrganizer = new EventOrganizer { User = user },
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
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                        User = new User{Role = UserRole.Member }
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Entity Framework advanced",
                Description = "Some cool examples of advanced topics in Entity framework.\n" + lorem,
                Lecturer = "Jan Adamec",
                Date = new DateTime(2016, 12, 1),
                Start = new TimeSpan(16, 30, 0),
                End = new TimeSpan(19, 0, 0),
                EventOrganizer = new EventOrganizer { User = user },
                Capacity = 10,
                Fee = 20,
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Unpaid,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Unpaid,
                        User = new User{Role = UserRole.Member }
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Windows 10",
                Description = "Introduction to new operating system Windows 10. We will look on basic functionality and also some new cool features.",
                Lecturer = "Fernando Torrez",
                Date = new DateTime(2016, 2, 1),
                Start = new TimeSpan(17, 30, 0),
                End = new TimeSpan(20, 0, 0),
                EventOrganizer = new EventOrganizer { User = user },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = address,
                Title = "ASP.NET MVC",
                Description = lorem,
                Lecturer = "Fernando Torrez",
                Date = new DateTime(2016, 7, 20),
                Start = new TimeSpan(18, 30, 0),
                End = new TimeSpan(21, 0, 0),
                EventOrganizer = new EventOrganizer { User = user },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Unit testing",
                Description = lorem,
                Lecturer = "Jiří Novotný",
                Date = new DateTime(2016, 9, 28),
                Start = new TimeSpan(15, 30, 0),
                End = new TimeSpan(17, 0, 0),
                EventOrganizer = new EventOrganizer { User = new User {Role = UserRole.Organizer} },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    }
                }
            });

            context.Events.Add(new Event
            {
                Address = address,
                Title = ".NET Core",
                Description = lorem,
                Lecturer = "Jiří Novotný",
                Date = new DateTime(2016, 11, 28),
                Start = new TimeSpan(14, 00, 0),
                End = new TimeSpan(17, 0, 0),
                EventOrganizer = new EventOrganizer { User = user },
                Registrations = new List<Registration>
                {
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    },
                    new Registration
                    {
                        State = RegistrationState.Accepted,
                          User = new User{Role = UserRole.Member }
                    }
                }
            });

            context.SaveChanges();
        }
    }
}