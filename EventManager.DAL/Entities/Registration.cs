using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DAL.Entities
{
    public class Registration : IEntity<int>
    {
        public int ID { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
