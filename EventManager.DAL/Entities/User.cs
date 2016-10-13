using EventManager.DAL.Enums;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManager.DAL.Entities
{
    /// <summary>
    /// User in application with his role.
    /// </summary>
    public class User : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        public UserRole Role { get; set; }
        //[Required] disabled only for DAL test purpose
        public virtual UserAccount Account { get; set; }
        public virtual List<Registration> Registrations { get; set; }
        public virtual List<EventOrganizer> EventOrganizers { get; set; }
    }
}
