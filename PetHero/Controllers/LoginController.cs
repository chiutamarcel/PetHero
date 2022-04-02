using Microsoft.AspNetCore.Mvc;

namespace PetHero.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
