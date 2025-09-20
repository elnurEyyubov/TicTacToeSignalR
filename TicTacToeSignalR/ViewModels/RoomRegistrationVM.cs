using TicTacToeSignalR.Models;

namespace TicTacToeSignalR.ViewModels
{
    public class RoomRegistrationVM
    {
        public string Name { get; set; }
        public bool isPrivate { get; set; }
        public string? Password { get; set; }


        public static implicit operator Game(RoomRegistrationVM vm)
        {
            return new Game
            {
                Name = vm.Name,
                isPrivate = vm.isPrivate,
                Password = vm.isPrivate ? vm.Password : null,
                GameStatus = "waiting"

            };
        }
    }
}
