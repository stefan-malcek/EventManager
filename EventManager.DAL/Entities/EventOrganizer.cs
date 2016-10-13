using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;
using EventManager.DAL.Validation;

namespace EventManager.DAL.Entities
{
    /// <summary>
    /// EventOrganizer = lecturer.
    /// </summary>
    public class EventOrganizer : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        public virtual Event Event { get; set; }
        [Required]
        [Organizer]
        public virtual User User { get; set; }
    }
}
