using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeSignalR.Models
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> players { get; set; }
        public string GameStatus { get; set; } = "waiting"; // waiting / in-progress / finished
        public bool isPrivate { get; set; }
        public string? Password { get; set; }
        
        public string[] GameData { get; } = ["", "", "", "", "", "", "", "", "", ""];
    }
}
