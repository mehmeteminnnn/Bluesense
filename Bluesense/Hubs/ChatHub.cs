using Microsoft.AspNetCore.SignalR;

namespace Bluesense.Hubs
{
    public class ChatHub : Hub
    {
        // Kullanıcılar gruba katılabilir, mesaj gönderebilir
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessageToGroup(string groupName, string user, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
        }
    }
}