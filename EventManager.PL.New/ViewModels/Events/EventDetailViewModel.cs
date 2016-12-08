using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.DTOs.Users;

namespace EventManager.PL.ViewModels.Events
{
    public class EventDetailViewModel
    {
        public EventDetailDTO EventDetail { get; set; }
        public AddressDTO Address { get; set; }
        public UserDTO Organizer { get; set; }
    }
}