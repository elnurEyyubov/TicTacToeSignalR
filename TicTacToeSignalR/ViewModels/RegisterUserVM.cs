
using System.Drawing;

namespace TicTacToeSignalR.ViewModels
{
    public class RegisterUserVM
    {
        public string Username { get; set; }
        public IFormFile? Image { get; set; }
        public string Password { get; set; }

    }
}
