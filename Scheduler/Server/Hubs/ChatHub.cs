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

        public async Task SendChat(List<ChatMessage> chatMessages,string roomName)
        {
            await Clients.Group(roomName).SendAsync("ReceiveChat", chatMessages);
        }
        public async Task SendMessage(ScheduleData scheduleData)
        {
            await Clients.Group(scheduleData.RoomID).SendAsync("ReceiveMessage", scheduleData);
        }
        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.OthersInGroup(roomName).SendAsync("ReceiveMessage", new ScheduleData(){
                ConnectionId = Context.ConnectionId,
                Event = ScheduleEvent.Event.Planting,
                EventType = ScheduleEvent.EventType.SeedRequest
            });
        }
        public async Task PlantingMessage(ScheduleData scheduleData)
        {

            switch(scheduleData.EventType){
                case (ScheduleEvent.EventType.SeedInfo) :
                    string receiver = scheduleData.ConnectionId;
                    scheduleData.ConnectionId = Context.ConnectionId;
                    scheduleData.EventType = ScheduleEvent.EventType.SeedInfo;
                    await Clients.Client(receiver).SendAsync("ReceiveMessage", scheduleData);

                    break;
                case (ScheduleEvent.EventType.SeedAccept):
                    string giver = scheduleData.ConnectionId;
                    scheduleData.ConnectionId = Context.ConnectionId;
                    await Clients.Client(giver).SendAsync("ReceiveMessage", scheduleData);

                    break;
                case (ScheduleEvent.EventType.Seeding):
                    await Clients.Client(scheduleData.ConnectionId).SendAsync("ReceiveMessage", scheduleData);

                    break;
            }
    
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

    }
}