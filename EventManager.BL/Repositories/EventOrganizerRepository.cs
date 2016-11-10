using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Repositories
{
    public class EventOrganizerRepository : EntityFrameworkRepository<EventOrganizer, int>
    {
        public EventOrganizerRepository(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
