using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs
{
   public  class RegistrationCreate
    {
        [Required]
        public RegistrationState State { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
