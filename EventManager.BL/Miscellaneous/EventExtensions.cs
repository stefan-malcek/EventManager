using System;
using EventManager.DAL.Entities;

namespace EventManager.BL.Miscellaneous
{
    public static class EventExtensions
    {
        /// <summary>
        /// Return event date and event start time as one object.
        /// </summary>
        /// <param name="event">event</param>
        /// <returns>start dateTime of event</returns>
        public static DateTime GetStartDateTime(this Event @event)
        {
            return @event.Date.Add(@event.Start);
        }
    }
}
