using Riganti.Utils.Infrastructure.EntityFramework;
using System.Data.Entity;
using EventManager.DAL.Entities;

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
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureMembershipRebootUserAccounts<UserAccount>();
        }
    }
}
