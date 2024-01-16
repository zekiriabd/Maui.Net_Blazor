using Microsoft.AspNetCore.SignalR;

namespace ApiServer.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddMessageToChat(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
