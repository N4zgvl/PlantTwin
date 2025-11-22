using PlantTwin.Interfaces;
using PlantTwin.Models;

namespace PlantTwin.Patterns.State
{
    public class MantenimientoState : IMachineState
    {
        public string NombreEstado => "Mantenimiento";
        public void Handle(Machine m)
        {
            // reducir actividad durante mantenimiento
            m.Rpm = 0;
            m.Temperature = Math.Max(20, m.Temperature - 1.0);
        }
    }
}
