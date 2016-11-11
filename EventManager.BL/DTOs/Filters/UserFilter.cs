using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DAL.Enums;

namespace EventManager.BL.DTOs.Filters
{
    public class UserFilter
    {
        public UserRole? Role { get; set; }
    }
}
