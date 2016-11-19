using EventManager.BL.DTOs.Filters;

namespace EventManager.BL.DTOs.Events
{
    public class EventPagedListResultDTO : PagedListResultDTO<EventDTO>
    {
        public EventFilter Filter { get; set; }
    }
}
