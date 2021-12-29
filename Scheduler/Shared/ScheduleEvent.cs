using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Shared
{
    public class ScheduleEvent
    {
        public enum Event
        {
            Timetable,
            UserEvent,
            Appointment,
            Planting,
            JoinRoom,
            Unkown

        }
        public enum EventType
        {
            Add,
            Edit,
            Delete,
            Seeding,
            SeedRequest,
            SeedInfo,
            SeedAccept,

        }
    }
}
