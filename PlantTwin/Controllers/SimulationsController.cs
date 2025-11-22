using Microsoft.AspNetCore.Mvc;
using PlantTwin.Services;

namespace PlantTwin.Controllers
{
    public class SimulationsController : Controller
    {
        [HttpPost]
        public IActionResult HighTemp()
        {
            HistoryService.AddEvent("Sistema", "Simulación: Pico de temperatura");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PowerFail()
        {
            HistoryService.AddEvent("Sistema", "Simulación: Falla eléctrica");
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
