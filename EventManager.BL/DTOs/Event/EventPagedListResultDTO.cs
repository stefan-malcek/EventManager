using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs.Filters;

namespace EventManager.BL.DTOs.Event
{
    public class EventPagedListResultDTO : PagedListResultDTO<EventDTO>
    {
        public EventFilter Filter { get; set; }
    }
}
