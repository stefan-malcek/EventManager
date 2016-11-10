using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Registration
{
   public  class RegistrationCreateDTO
    {
        [Required]
        public RegistrationState State { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
