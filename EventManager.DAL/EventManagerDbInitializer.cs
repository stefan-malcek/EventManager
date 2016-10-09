using EventManager.DAL.Entities;
using System;
using System.Data.Entity;
using EventManager.DAL.Enums;

namespace EventManager.DAL
{
    public class EventManagerDbInitializer : DropCreateDatabaseAlways<EventManagerDbContext>
    {
        public override void InitializeDatabase(EventManagerDbContext context)
        {
            base.InitializeDatabase(context);
            //context.Database.Log = Console.Write;
            var address = new Address
            {
                Street = "Botanická",
                StreetNumber = "68a",
                City = "Brno",
                ZipCode = 60200,
                State = "Česká republika"
            };

            context.Addresses.Add(address);
            context.Addresses.Add(new Address
            {
                Street = "Božetěchova",
                StreetNumber = "1/2",
                City = "Brno",
                ZipCode = 61266,
                State = "Česká republika"
            });

            var organizer = new User
            {
                Role = UserRole.Organizer
            };

            context.Users.Add(organizer);

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Entity Framework basic",
                Description = "ef",
                Date = new DateTime(2016, 11, 1),
                Start = new TimeSpan(14, 0, 0),
                End = new TimeSpan(16, 0, 0),
                Organizer = organizer
            });

            context.Events.Add(new Event
            {
                Address = address,
                Title = "Entity Framework advanced",
                Description = "ef",
                Date = new DateTime(2016, 11, 1),
                Start = new TimeSpan(16, 30, 0),
                End = new TimeSpan(19, 0, 0),
                Organizer = organizer,
                Capacity = 100,
                Fee = 20
            });

            context.SaveChanges();
        }
    }
}