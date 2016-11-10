using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Registration
{
    public class RegistrationUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public RegistrationState State { get; set; }
    }
}
