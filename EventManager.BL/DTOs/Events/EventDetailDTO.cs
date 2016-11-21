using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Registrations;

namespace EventManager.BL.DTOs.Events
{
    public class EventDetailDTO
    {
        [Required]
        public EventDTO Event { get; set; }
        public double AverageRating { get; set; }
        public bool IsEnded { get; set; }
        public IEnumerable<RegistrationDTO> Registrations { get; set; }
        public IEnumerable<EventReviewDTO> Reviews { get; set; }
    }
}
