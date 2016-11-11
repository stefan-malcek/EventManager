using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Validation;

namespace EventManager.BL.DTOs
{
    public class EventOrganizerDTO
    {
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        [Organizer]
        public int UserId { get; set; }
    }
}
