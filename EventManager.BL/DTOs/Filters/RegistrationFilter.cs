using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Filters
{
    public class RegistrationFilter
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public RegistrationState? State { get; set; }
    }
}
