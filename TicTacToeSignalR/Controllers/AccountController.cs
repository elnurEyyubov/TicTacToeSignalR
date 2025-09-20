using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicTacToeSignalR.Extensions;
using TicTacToeSignalR.Models;
using TicTacToeSignalR.ViewModels;

namespace TicTacToeSignalR.Controllers
{
    public class AccountController(IWebHostEnvironment _env,UserManager<User> _userManager, SignInManager<User> _signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM vm)
        {
            if (vm == null) return RedirectToAction(nameof(Register));

            if (vm.Username is null || vm.Password is null) return RedirectToAction(nameof(Register));
            vm.Username = vm.Username.Trim();
            var user = new User
            {
                UserName = vm.Username,
                isInGame = false
            };

            string filename = "";
            if (vm.Image != null)
            {
                if (!vm.Image.isValidType("image") || !vm.Image.isValidSize(1000))
                {
                    ModelState.AddModelError("File", "File must be image less than 1000 kilobites");
                }
                user.ImageUrl = await vm.Image.UploadAsync(_env.WebRootPath, "imgs");

            } else
            {
                user.ImageUrl = "default-profile.jpg";
            }

            var result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                RedirectToAction(nameof(Register));
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM vm)
        {
            if (vm == null) return RedirectToAction(nameof(Login));

            if (vm.Username is null || vm.Password is null) return RedirectToAction(nameof(Login));
            vm.Username = vm.Username.Trim();
            var user = await _userManager.FindByNameAsync(vm.Username);
            if (user is null) return RedirectToAction(nameof(Login));

            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, true, true);
            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
