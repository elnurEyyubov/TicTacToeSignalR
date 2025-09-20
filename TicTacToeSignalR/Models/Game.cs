namespace TicTacToeSignalR.Models
{
    public class Game
    {
        public int Id { get; set; }
        public ICollection<User> players { get; set; }
        public string GameStatus { get; set; } // waiting / in-progress / finished
        public string isPrivate { get; set; }
        public string? Password { get; set; }
        
        public string[] GameData { get; } = ["", "", "", "", "", "", "", "", "", ""];
    }
}
