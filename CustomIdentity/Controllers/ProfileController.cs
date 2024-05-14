using Microsoft.AspNetCore.Mvc;

namespace CustomIdentity.Controllers
{
    public class ProfileController : Controller
    {


        public ProfileController()
        {
            
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register() {
        return View();
        }
        
        public IActionResult Logout()
        {
            return View();
        }



    }
}
