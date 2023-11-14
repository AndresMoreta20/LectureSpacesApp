using Microsoft.AspNetCore.Mvc;

namespace LectureSpacesApp.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
