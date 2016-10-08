using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.DAL.Entities
{
    public class Event : IEntity<int>
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [NotMapped]
        public TimeSpan Duration { get { return End - Start; } }
        public int? Capacity { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Registration> Registrations { get; set; }
    }
}
