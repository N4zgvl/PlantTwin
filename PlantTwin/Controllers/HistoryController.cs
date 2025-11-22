using Microsoft.AspNetCore.Mvc;
using PlantTwin.Services;

namespace PlantTwin.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            var eventos = HistoryService.GetAll();
            return View(eventos);
        }
    }
}
