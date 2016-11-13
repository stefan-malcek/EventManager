using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Services
{
    public abstract class EventManagerService
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
    }
}
