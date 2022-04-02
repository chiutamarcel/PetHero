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

        [HttpGet("/login")]
        public int Login(string username, string password)
        {
            User user = _db.Users.Where(u => (u.Username == username && u.Password == password)).FirstOrDefault();
            if (user == null) return 0;
            else return 1;
        }

        public JsonResult Index()
        {
            User user = _db.Users.First();

            return Json(user);
        }
    }
}
