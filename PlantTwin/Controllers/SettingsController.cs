using Microsoft.AspNetCore.Mvc;

namespace PlantTwin.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
