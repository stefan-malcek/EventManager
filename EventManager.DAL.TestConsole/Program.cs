using EventManager.DAL.Entities;
using System;
using System.Linq;

namespace EventManager.DAL.TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EventManagerDbContext())
            {
                context.Addresses.Add(new Address
                {
                    Street = "Vodova",
                    StreetNumber = "81",
                    City = "Brno",
                    ZipCode = 61200,
                    State = "Česká republika"
                });

                context.SaveChanges();
            }

            using (var context = new EventManagerDbContext())
            {
                foreach (var address in context.Addresses)
                {
                    Console.WriteLine(address);
                }
            }

            using (var context = new EventManagerDbContext())
            {
                foreach (var pEvent in context.Events)
                {
                    Console.WriteLine(pEvent);
                }
            }

            using (var context = new EventManagerDbContext())
            {
                var review = new EventReview
                {
                    Event = context.Events.First(),
                    Rating = 5
                };

                context.EventReviews.Add(review);
                context.SaveChanges();
            }

            using (var context = new EventManagerDbContext())
            {
                //context.Events.Remove(context.Events.First());
                //context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
