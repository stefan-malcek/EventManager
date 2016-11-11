using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Registrations
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        [Required]
        public RegistrationState State { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
