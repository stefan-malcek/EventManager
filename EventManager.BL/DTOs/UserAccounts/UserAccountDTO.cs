using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.BL.DTOs.UserAccounts
{
    public class UserAccountDTO
    {
        public Guid Id { get; set; }

        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}
