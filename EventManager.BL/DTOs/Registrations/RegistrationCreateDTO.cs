using System.ComponentModel.DataAnnotations;

namespace EventManager.BL.DTOs.Registrations
{
   public  class RegistrationCreateDTO
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
