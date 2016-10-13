using EventManager.DAL.Entities;
using System;
using System.Linq;

namespace EventManager.DAL.TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nAdd");

            using (var context = new EventManagerDbContext())
            {
                context.Addresses.Add(new Address
                {
                    Building = "BB centrum, budova Delta(kinosál Praha)",
                    Street = "Vyskočilova",
                    StreetNumber = "1561 / 4a",
                    City = "Praha 4"
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

            Console.WriteLine("\nUpdate");

            using (var context = new EventManagerDbContext())
            {
                var address = context.Addresses.FirstOrDefault();

                if (address != null)
                {
                    address.Building = "Fakulta informatiky Masarykovy univerzity (A318)";
                    address.Street = "Botanická";
                    address.StreetNumber = "68a";
                    address.City = "Brno";

                    context.SaveChanges();
                }
            }  

            using (var context = new EventManagerDbContext())
            {
                foreach (var address in context.Addresses)
                {
                    Console.WriteLine(address);
                }
            }

            Console.WriteLine("\nDelete");

            using (var context = new EventManagerDbContext())
            {
                var address = context.Addresses.FirstOrDefault();

                context.Addresses.Remove(address);
                context.SaveChanges();
            }

            using (var context = new EventManagerDbContext())
            {
                foreach (var address in context.Addresses)
                {
                    Console.WriteLine(address);
                }
            }

            Console.ReadKey();
        }
    }
}
