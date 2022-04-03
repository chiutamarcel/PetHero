using Microsoft.AspNetCore.Mvc;

namespace PetHero.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
