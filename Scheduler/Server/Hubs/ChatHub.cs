using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Scheduler.Shared;

namespace Scheduler.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message); 
        //}
        public async Task SendTimeTable(string user, string roomName, string urlString)
        {
            ScheduleData scheduleData = new ScheduleData()
            {
                Name = user,
                TimetableUrl = urlString,
                ThisEvent = ScheduleData.Event.Timetable
            };

            await Clients.Group(roomName).SendAsync("ReceiveMessage", scheduleData);
        }
        public async Task SendAppointment(ScheduleData scheduleData)
        {

            Console.WriteLine(Context.User);
            _logger.LogInformation(Context?.User?.ToString());
            await Clients.OthersInGroup(scheduleData.RoomID).SendAsync("ReceiveMessage", scheduleData);
        }
        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);

        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

    }
}