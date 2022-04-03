using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHero.Areas.Identity.Data;
using PetHero.Models;
using System.Diagnostics;

namespace PetHero.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _db = db;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<HelpRequest> helpRequest = _db.HelpRequests;
            return View(helpRequest);
        }

        [HttpGet]
        public IActionResult GetCreatePage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHelpRequest(CreateHelpRequestModel helpRequestModel)
        {
            
            if(helpRequestModel.ImageFile == null)
            {
                return Error();
            }

            string wwwPath = webHostEnvironment.WebRootPath;
            string contentPath = webHostEnvironment.ContentRootPath;

            string path = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string uniqueFileName = null;
            
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + helpRequestModel.ImageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                helpRequestModel.ImageFile.CopyTo(fileStream);
            }

            HelpRequest helpRequest = new HelpRequest
            {
                Id = helpRequestModel.Id,
                Title = helpRequestModel.Title,
                Description = helpRequestModel.Description,
                LastLocation = helpRequestModel.LastLocation,
                ImagePath = "/Uploads/" + uniqueFileName,
                PhoneNr = helpRequestModel.PhoneNr
            };

            _db.HelpRequests.Add(helpRequest);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}