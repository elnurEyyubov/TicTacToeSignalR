using Microsoft.AspNetCore.SignalR;

namespace TicTacToeSignalR.Hubs
{
    public class LobbyHub : Hub
    {

        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
    }
}
