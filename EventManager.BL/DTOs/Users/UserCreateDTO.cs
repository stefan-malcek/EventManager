using System;
using System.ComponentModel.DataAnnotations;
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
