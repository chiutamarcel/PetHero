using Microsoft.AspNetCore.Mvc;
using PetHero.Data;

namespace PetHero.Controllers
{
    public class LoginController : Controller
    {
        public ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        public JsonResult Index()
        {
            User user = _db.Users.First();

            return Json(user);
        }
    }
}
