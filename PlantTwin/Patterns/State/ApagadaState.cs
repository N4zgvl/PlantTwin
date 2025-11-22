using PlantTwin.Interfaces;
using PlantTwin.Models;

namespace PlantTwin.Patterns.State
{
    public class ApagadaState : IMachineState
    {
        public string NombreEstado => "Apagada";
        public void Handle(Machine m)
        {
            m.Rpm = 0;
            // temperatura va decayendo
            m.Temperature = Math.Max(20, m.Temperature - 0.5);
        }
    }
}
