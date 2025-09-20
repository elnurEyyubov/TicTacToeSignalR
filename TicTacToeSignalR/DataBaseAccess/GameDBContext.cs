using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TicTacToeSignalR.Models;

namespace TicTacToeSignalR.DataBaseAccess
{
    public class GameDBContext : IdentityDbContext<User>
    {
        public GameDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected GameDBContext()
        {
        }
    }
}
