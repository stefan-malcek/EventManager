using EventManager.BL.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace EventManager.PL.ViewModels.Events
{
    public class EventListViewModel
    {
        public IPagedList<EventDTO> Events { get; set; }
    }
}