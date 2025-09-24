using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using TicTacToeSignalR.Models;

namespace TicTacToeSignalR.Hubs
{
    public class GameHub : Hub
    {
        public async Task StartGame(string gameName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameName);
            
            await Clients.Group(gameName).SendAsync("startgame", $"{gameName} is the name of the game and we start");
        }


    }
}
