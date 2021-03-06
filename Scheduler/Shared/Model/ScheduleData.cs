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
        public string ConnectionId { get; set; }
        public int UpdateCount { get; set; }
        public List<AppointmentData> Appointments { get; set; } = new List<AppointmentData>();
        public List<TimetableLink> TimetableLinks { get; set; } = new List<TimetableLink>();
        public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

        public List<UserData> UserDatas { get; set; } = new List<UserData>();
        public Event Event { get; set; } = Event.Timetable;
        public EventType EventType { get; set; }

      

    }
}
