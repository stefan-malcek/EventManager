using System.Collections.Generic;

namespace EventManager.BL.DTOs
{
    public abstract class PagedListResultDTO<T>
    {
        public int TotalResultCount { get; set; }
        public int RequestedPage { get; set; }
        public IEnumerable<T> ResultPageData { get; set; }
    }
}
