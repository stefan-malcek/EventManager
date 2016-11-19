using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Repositories
{
    public class AddressRepository : EntityFrameworkRepository<Address, int>
    {
        public AddressRepository(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
