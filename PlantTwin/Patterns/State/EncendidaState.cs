using PlantTwin.Interfaces;
using PlantTwin.Models;

namespace PlantTwin.Patterns.State
{
    public class EncendidaState : IMachineState
    {
        public string NombreEstado => "Encendida";
        public void Handle(Machine m)
        {
            m.Temperature += 0.3;
            m.Rpm += 5;
        }
    }
}
