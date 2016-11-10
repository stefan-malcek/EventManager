using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs
{
    public class RegistrationUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public RegistrationState State { get; set; }
    }
}
