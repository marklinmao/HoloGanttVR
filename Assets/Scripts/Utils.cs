using System;
using System.Globalization;


namespace HoloGanttVR
{

    public class Utils
    {
        /// <summary>
        /// e.g. the format of datetime can be "2018-10-30".
        /// </summary>
        /// <param name="dateTimeStr"></param>
        /// <returns></returns>
        public static DateTime ConvertDateTime(string dateTimeStr)
        {
            return DateTime.ParseExact(dateTimeStr, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None);
        }

        /// <summary>
        /// Calculate the duration of working days between two dates.
        /// </summary>
        /// <param name="from">'from' date-time</param>
        /// <param name="to">'to' date-time</param>
        /// <returns></returns>
        public static int GetWorkingDays(DateTime from, DateTime to)
        {
            var totalDays = 0;
            for (var date = from; date < to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday)
                    totalDays++;
            }

            return totalDays;
        }

    }

}

