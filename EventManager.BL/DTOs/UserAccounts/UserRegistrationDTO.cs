using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.BL.DTOs.UserAccounts
{
    public class UserRegistrationDTO
    {
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}
