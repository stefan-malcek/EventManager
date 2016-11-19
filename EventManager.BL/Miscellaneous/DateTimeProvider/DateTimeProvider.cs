using System;

namespace EventManager.BL.Miscellaneous.DateTimeProvider
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrectDateTime()
        {
            return DateTime.Now;
        }
    }
}
