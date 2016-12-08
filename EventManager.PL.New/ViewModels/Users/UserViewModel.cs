using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.BL.DTOs.Users;

namespace EventManager.PL.ViewModels.Users
{
    public class UserViewModel
    {
        public UserDTO User { get; set; }
        public SelectList UserRoles { get; set; }
    }
}