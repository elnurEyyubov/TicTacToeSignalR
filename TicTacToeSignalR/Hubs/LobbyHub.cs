using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TicTacToeSignalR.DataBaseAccess;
using TicTacToeSignalR.ViewModels;

namespace TicTacToeSignalR.Hubs
{
    public class LobbyHub(GameDBContext _context) : Hub
    {

        public async override Task OnConnectedAsync()
        {
            //    if (Context.User is not null)
            //    {

            //    }
            //    await base.OnConnectedAsync();
            await SendRooms();
        }

        public async Task SendRooms()
        {
            var rooms = _context.Games
                .Where(x => x.GameStatus == "waiting" || x.GameStatus == "in-progress")
                .Select(x => new RoomLobbyVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.GameStatus,
                    IsPrivate = x.isPrivate,
                })
                .ToList();
            await Clients.All.SendAsync("ReceiveRooms", rooms);
        }


    }
}
