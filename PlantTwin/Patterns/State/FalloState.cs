using PlantTwin.Interfaces;
using PlantTwin.Models;

namespace PlantTwin.Patterns.State
{
    public class FalloState : IMachineState
    {
        public string NombreEstado => "Fallo";
        public void Handle(Machine m)
        {
            m.Rpm = 0;
            m.Events.Add(new EventLog { Timestamp = DateTime.UtcNow, Message = "Fallo detectado" });
        }
    }
}
