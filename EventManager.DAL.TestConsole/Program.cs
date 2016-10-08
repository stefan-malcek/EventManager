using EventManager.DAL.Entities;
using EventManager.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DAL.TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EventManagerDbContext())
            {
                context.Users.Add(new User
                {
                    FirstName = "Štefan",
                    LastName = "Malček",
                    Birthday = DateTime.Now,
                    Type = UserType.Administrator,
                });

                context.SaveChanges();
            }

            using (var context = new EventManagerDbContext())
            {
                foreach (var user in context.Users)
                {
                    Console.WriteLine(user);
                }
            }

            Console.ReadKey();
        }
    }
}
