using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Repositories
{
    public class RegistrationRepository : EntityFrameworkRepository<Registration, int>
    {
        public RegistrationRepository(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
