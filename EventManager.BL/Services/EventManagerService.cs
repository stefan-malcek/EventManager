using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Services
{
    public abstract class EventManagerService
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
    }
}
