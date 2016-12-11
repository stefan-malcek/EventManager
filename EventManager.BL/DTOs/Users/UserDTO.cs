using System;
using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Role { get; set; }
        public string Email { get; set; }
        //[DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
