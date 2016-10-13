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
                    new EventReview {Rating = 5}
                }
            });

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Entity Framework advanced",
                Description = "Some cool definition of advanced topics in Entity framework.",
                Lecturer = "Jan Adamec",
                Date = new DateTime(2016, 11, 1),
                Start = new TimeSpan(16, 30, 0),
                End = new TimeSpan(19, 0, 0),
                EventOrganizer = new EventOrganizer { User = user },
                Capacity = 100,
                Fee = 20
            });

            context.SaveChanges();
        }
    }
}