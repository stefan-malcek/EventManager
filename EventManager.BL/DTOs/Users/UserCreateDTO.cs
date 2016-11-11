using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Users
{
    public class UserCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}
