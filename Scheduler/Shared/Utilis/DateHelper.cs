using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Shared.Utilis
{
    public class DateHelper
    {
        public static int NumberOfDays(string weekDay)
        {
            return "Sunday" == weekDay
            ? 6
            : "Tuesday" == weekDay
            ? 1
            : "Wednesday" == weekDay
            ? 2
            : "Thursday" == weekDay
            ? 3
            : "Friday" == weekDay
            ? 4
            : "Saturday" == weekDay
            ? 5
            : 0;
        }
    }
}
