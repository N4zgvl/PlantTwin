using Microsoft.AspNetCore.Mvc;
using PlantTwin.Models;
using PlantTwin.Patterns.Command;
using PlantTwin.Services;
using PlantTwin.ViewModels;

namespace PlantTwin.Controllers
{
    public class PlantController : Controller
    {
        private static readonly List<Machine> _machines = new();
        private readonly MachineSimulatorService _sim;
        private readonly NotifierService _notifier;

        public PlantController(MachineSimulatorService sim, NotifierService notifier)
        {
            _sim = sim; _notifier = notifier;
            if (!_machines.Any())
            {
                _machines.Add(MachineFactory.Create("normal", "CNC-03"));
                _machines.Add(MachineFactory.Create("normal", "Prensa-01"));
            }
        }

        public IActionResult Index()
        {
            var vm = new DashboardViewModel { Machines = _machines, SystemLog = _notifier.Log };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Start(string id)
        {
            var m = _machines.FirstOrDefault(x => x.Id == id);
            if (m != null)
            {
                var cmd = new StartCommand(m);
                cmd.Execute();
                _ = _sim.StartSimulationAsync(m);

                HistoryService.AddEvent(m.Name, "Máquina iniciada");

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Stop(string id)
        {
            var m = _machines.FirstOrDefault(x => x.Id == id);
            if (m != null)
            {
                var cmd = new StopCommand(m);
                cmd.Execute();
                _sim.StopSimulation(m);
                HistoryService.AddEvent(m.Name, "Máquina detenida");

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Clone(string id)
        {
            var m = _machines.FirstOrDefault(x => x.Id == id);
            if (m != null)
            {
                var clone = MachineFactory.Clone(m);
                _machines.Add(clone);
                HistoryService.AddEvent(m.Name, "Máquina clonada");

            }
            return RedirectToAction("Index");
        }

        public IActionResult Charts()
        {
            return View();
        }
    }
}
