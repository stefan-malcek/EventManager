using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Riganti.Utils.Infrastructure.EntityFramework;
using System.Data.Entity;
using EventManager.DAL.Entities;

namespace EventManager.DAL
{
    public class EventManagerDbContext : DbContext
    {
        public EventManagerDbContext() : base("EventManagerDBContext")
        {
            //InitializeDbContext();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
