using EventManager.DAL.Enums;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManager.DAL.Entities
{
    public class User : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        [Range(0, 2)]
        public UserRole Role { get; set; }
        //[Required] for now is not required - testing db layer
        public virtual UserAccount Account { get; set; }
        public virtual List<Event> Events { get; set; }
        public virtual List<Registration> Registrations { get; set; }
    }
}
