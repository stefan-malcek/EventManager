using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Registrations
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public RegistrationState State { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }


        public override string ToString()
        {
            return State.ToString();
        }
    }
}
