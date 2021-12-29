using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scheduler.Shared.ScheduleEvent;

namespace Scheduler.Shared
{
    public class ScheduleData
    {
        public string RoomID { get; set; }
        public string? Name { get; set; }

        public List<AppointmentData> Appointments { get; set; } = new List<AppointmentData>();
        public List<TimetableLink> TimetableLinks { get; set; } = new List<TimetableLink>();
        public Event Event { get; set; } = Event.Timetable;
        public EventType EventType { get; set; }

      

    }
}
