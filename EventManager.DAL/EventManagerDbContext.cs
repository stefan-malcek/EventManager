using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;
using EventManager.DAL.Entities;
using UserAccount = EventManager.DAL.Entities.UserAccount;

namespace EventManager.DAL
{
    public class EventManagerDbContext : DbContext
    {
        public EventManagerDbContext() : base("EventManagerDBContext")
        {
            Database.SetInitializer(new EventManagerDbInitializer());
          
                this.RegisterUserAccountChildTablesForDelete<UserAccount>();
           
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventReview> EventReviews { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureMembershipRebootUserAccounts<UserAccount>();

            modelBuilder.Entity<Event>()
                .HasRequired(h => h.EventOrganizer)
                .WithRequiredDependent(w => w.Event);
        }

        public override int SaveChanges()
        {

            return base.SaveChanges();

        }
    }
}
