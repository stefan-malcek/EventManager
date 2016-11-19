using System.Collections.Generic;
using EventManager.BL.DTOs.Events;
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

        IEnumerable<EventDTO> ListEvents();

        EventPagedListResultDTO ListEvents(EventFilter filter, int page = 1);
    }
}
