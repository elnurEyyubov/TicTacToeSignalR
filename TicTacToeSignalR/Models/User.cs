using Microsoft.AspNetCore.Identity;

namespace TicTacToeSignalR.Models
{
    public class User : IdentityUser
    {
        public string? ImageUrl { get; set; }
        public bool isInGame { get; set; }
        public Game? game { get; set; } = null;
    }
}
