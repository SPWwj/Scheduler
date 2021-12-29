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


        public async Task SendMessage(ScheduleData scheduleData)
        {
            _logger.LogInformation(Context?.User?.ToString());
            await Clients.Group(scheduleData.RoomID).SendAsync("ReceiveMessage", scheduleData);
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