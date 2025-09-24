using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TicTacToeSignalR.DataBaseAccess;
using TicTacToeSignalR.Hubs;
using TicTacToeSignalR.Models;
using TicTacToeSignalR.ViewModels;

namespace TicTacToeSignalR.Controllers
{
    [Authorize]
    public class HomeController(GameDBContext _context) : Controller
    {
        
        public IActionResult Index()
        {
            if (ViewData["Error"] is not null)
            {
                ViewBag.Error = ViewData["Error"];
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomRegistrationVM vm)
        {
            if (vm is null)
            {
                return RedirectToAction(nameof(Index));                
            }
            if (vm.Name is null || (vm.isPrivate && vm.Password is null))
            {
                ViewData["Error"] = "Give name to room and password if room is private";
                return RedirectToAction(nameof(Index));
            }
            vm.Name = vm.Name.Trim();
            Game game = vm;
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        public async Task<IActionResult> GamePage(int roomId)
        {
            var room = await _context.Games.FirstOrDefaultAsync(x => x.Id == roomId);
            //if (room == null || (!room.isPrivate && password is not null))
            //{
            //    return BadRequest();
            //}

            string name = User.Identity.Name;
            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == name);
            if (user == null)
            {
                return BadRequest();
            }
            if (room.players.Count() == 1)
            {
                room.players.Add(user);
                //GameHub hub = new();
                //await hub.StartGame(room);
            } else if (room.players.Count() == 0)
            {
                room.players.Add(user);
            } else
            {
                return Ok("Game is full");
            }

            user.isInGame = true;
            user.game = room;

            await _context.SaveChangesAsync();
            ViewBag.gamename = room.Name;
            return View();
        }

    }
}
