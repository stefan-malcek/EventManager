using System;
using EventManager.BL.Miscellaneous;

namespace EventManager.BL.DTOs.Filters
{
    public class EventFilter
    {
        public string Title { get; set; }
        public string Lecturer { get; set; }
        public double Rating { get; set; }
        public bool IsFree { get; set; }
        public bool IsNotFull { get; set; }
        public bool OnlyActual { get; set; }
        public EventSortCriteria SortCriteria { get; set; }
        public bool SortAscending { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
    }
}
