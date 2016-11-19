using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Repositories
{
    public class UserRepository : EntityFrameworkRepository<User, int>
    {
        public UserRepository(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
