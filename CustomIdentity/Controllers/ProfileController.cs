using CustomIdentity.Data;
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
        private readonly AppDbContext _context;

        public ProfileController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,AppDbContext context)
        {

            this._userManager = userManager;
            this._signInManager = signInManager;
            this._context = context;
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
        public async Task<IActionResult> Register(RegisterVM model)
        {
  
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Profile");
        }



    }
}
