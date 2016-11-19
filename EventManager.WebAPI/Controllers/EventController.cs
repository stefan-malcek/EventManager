using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventManager.BL.DTOs.Events;
using EventManager.BL.Facades;

namespace EventManager.WebAPI.Controllers
{
    public class EventController : ApiController
    {
        public EventFacade EventFacade { get; set; }

        public IEnumerable<EventDTO> Get()
        {
            return EventFacade.ListEvents();
        }

        [Route("~/api/Event/{id}")]
        public EventDetailDTO GetEventDetail(int id)
        {
            return id <= 0 ? null : EventFacade.GetEventDetail(id);
        }
    }
}
