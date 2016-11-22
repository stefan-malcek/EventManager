using EventManager.BL.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.PL.ViewModels.Events
{
    public class EventIndexViewModel
    {
        public EventPagedListResultDTO LaterEvents { get; set; }
        public EventPagedListResultDTO FurtherEvents { get; set; }
    }
}