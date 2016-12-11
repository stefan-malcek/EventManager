using EventManager.DAL.Entities;
using System.Data.Entity;

namespace EventManager.DAL
{
    public class EventManagerDbInitializer : DropCreateDatabaseAlways<EventManagerDbContext>
    {
        public override void InitializeDatabase(EventManagerDbContext context)
        {
            base.InitializeDatabase(context);

            context.Addresses.Add(new Address
            {
                Building = "Školící místnost společnosti Edhouse s.r.o. (Vědeckotechnický park ICT, budova A, 3. Patro)",
                Street = "Nad Stráněmi",
                StreetNumber = "5656",
                City = "Zlín"
            });

            context.Addresses.Add(new Address
            {
                Building = "Technologické centrum Hradec Králové",
                Street = "Piletická",
                StreetNumber = "486 / 19",
                City = "Hradec Králové"
            });
            
            context.SaveChanges();
        }
    }
}