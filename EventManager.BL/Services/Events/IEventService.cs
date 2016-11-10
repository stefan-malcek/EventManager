using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Event;
using EventManager.BL.DTOs.Filters;

namespace EventManager.BL.Services.Events
{
    public interface IEventService
    {
        int EventPageSize { get; }

        void CreateEvent(EventDTO eventDto);

        void UpdateEvent(EventDTO eventDto);

        void DeleteEvent(int eventId);

        EventDTO GetEvent(int eventId);

        PagedListResultDTO<EventDTO> ListEvents(EventFilter filter, int page = 1);
    }
}
