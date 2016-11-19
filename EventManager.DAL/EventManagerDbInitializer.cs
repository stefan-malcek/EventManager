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

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Entity Framework basics",
                Description = "Just basic stuff.",
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
                        Review = "I missed something there."
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
                Description = "Some cool examples of advanced topics in Entity framework.",
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

            context.SaveChanges();
        }
    }
}