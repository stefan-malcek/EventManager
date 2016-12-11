using EventManager.BL.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Miscellaneous;
using X.PagedList;

namespace EventManager.PL.ViewModels.Events
{
    public class EventListViewModel
    {
        public IPagedList<EventDTO> EventsPage { get; set; }
        public EventFilter Filter { get; set; }
        public SelectList AllSortCriteria => new SelectList(Enum.GetNames(typeof(EventSortCriteria)).ToList());
    }
}