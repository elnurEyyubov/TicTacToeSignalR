

using System.Reflection.Metadata.Ecma335;

namespace TicTacToeSignalR.ViewModels
{
    public class RoomLobbyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsPrivate { get; set; }
    }
}
