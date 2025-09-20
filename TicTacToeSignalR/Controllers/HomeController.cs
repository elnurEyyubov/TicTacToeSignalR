using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicTacToeSignalR.Models;

namespace TicTacToeSignalR.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

    }
}
