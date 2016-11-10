using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Repositories
{
    public class EventRepository : EntityFrameworkRepository<Event, int>
    {
        public EventRepository(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
