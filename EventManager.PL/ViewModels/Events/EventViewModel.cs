using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.BL.DTOs.Events;

namespace EventManager.PL.ViewModels.Events
{
    public class EventViewModel
    {
        public EventDTO EventData { get; set; }
        public SelectList AddressList { get; set; }
        public SelectList Organizers { get; set; }
    }
}