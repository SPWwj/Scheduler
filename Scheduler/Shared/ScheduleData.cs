using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Shared
{
    public class ScheduleData
    {
        public string RoomID { get; set; }
        public List<AppointmentData> Appointments { get; set; } = new List<AppointmentData>();
        public string? Name { get; set; }
        public string? TimetableUrl { get; set; }
        public Event ThisEvent { get; set; } = Event.Timetable;
        public EventType ThisEventType { get; set; }

        public enum Event
        {
            Timetable,
            Appointment,
            Unkown

        }
        public enum EventType
        {
            Add,
            Edit,
            Delete

        }

    }
}
