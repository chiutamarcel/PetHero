using Microsoft.AspNetCore.Mvc;
using PetHero.Areas.Identity.Data;
using PetHero.Models;
using System.Diagnostics;

namespace PetHero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCreatePage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHelpRequest(HelpRequest helpRequest)
        {
            _db.HelpRequests.Add(helpRequest);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public JsonResult Index()
        //{
        //    var helpRequests = _db.HelpRequests;
        //    return Json(helpRequests);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}