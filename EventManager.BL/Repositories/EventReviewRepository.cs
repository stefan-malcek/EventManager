using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Repositories
{
    public class EventReviewRepository : EntityFrameworkRepository<EventReview, int>
    {
        public EventReviewRepository(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
