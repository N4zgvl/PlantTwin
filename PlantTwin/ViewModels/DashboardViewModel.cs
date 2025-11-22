using PlantTwin.Models;

namespace PlantTwin.ViewModels
{
    public class DashboardViewModel
    {
        public List<Machine> Machines { get; set; } = new();
        public List<string> SystemLog { get; set; } = new();
    }
}
