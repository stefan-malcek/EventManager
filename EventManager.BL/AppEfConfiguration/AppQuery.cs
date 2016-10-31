using EventManager.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.AppEfConfiguration
{
    public abstract class AppQuery<T> : EntityFrameworkQuery<T>
    {
        public new EventManagerDbContext Context => (EventManagerDbContext)base.Context;

        protected AppQuery(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
