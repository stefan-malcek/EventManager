using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
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
            Database.Log = s => Debug.WriteLine(s);
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
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieves the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Joins the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combines the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throws a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
