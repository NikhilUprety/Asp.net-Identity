using CustomIdentity.Models;
using CustomIdentity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomIdentity.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {

            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (user.Succeeded) {
                return RedirectToAction("Login", "Profile");
                }

                ModelState.AddModelError("", "Invalid login attempt");

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register() {
        return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {

            }
        }
        
        public IActionResult Logout()
        {
            return View();
        }



    }
}
