using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Client("asd").SendAsync(message);
        }

        public override async Task OnConnectedAsync()
        {
            string connid = Context.ConnectionId;
            await Clients.All.SendAsync("Login");
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
