using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.Repositories.UserAccount
{
    public class UserAccountRepository : EntityFrameworkRepository<DAL.Entities.UserAccount, Guid>
    {
        public UserAccountRepository(IUnitOfWorkProvider provider) : base(provider) { }
    }
}
