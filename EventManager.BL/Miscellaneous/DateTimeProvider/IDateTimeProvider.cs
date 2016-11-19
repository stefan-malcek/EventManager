using System;

namespace EventManager.BL.Miscellaneous.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Return currect DateTime.
        /// </summary>
        /// <returns>currect datetime</returns>
        DateTime GetCurrectDateTime();
    }
}
