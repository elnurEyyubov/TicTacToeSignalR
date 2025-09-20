using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using TicTacToeSignalR.DataBaseAccess;
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
            return RedirectToAction(nameof(Index));
        }

    }
}
