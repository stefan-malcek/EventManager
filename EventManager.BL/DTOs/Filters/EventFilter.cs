using System;
using EventManager.BL.Miscellaneous;

namespace EventManager.BL.DTOs.Filters
{
    public class EventFilter
    {
        public string Lecturer { get; set; }
        public DateTime Date { get; set; }
        public int MinimumCapacity { get; set; }
        public int MaximumFee { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public bool ListOnlyActual { get; set; }
        public EventSortCriteria SortCriteria { get; set; }
        public bool SortAscending { get; set; }
    }
}
