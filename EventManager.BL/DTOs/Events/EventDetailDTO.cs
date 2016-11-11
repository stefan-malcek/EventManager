using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Registrations;

namespace EventManager.BL.DTOs.Events
{
    public class EventDetailDTO
    {
        [Required]
        public EventDTO Event { get; set; }
        public IEnumerable<RegistrationDTO> Registrations { get; set; }
        public IEnumerable<EventReviewDTO> Reviews { get; set; }
    }
}
