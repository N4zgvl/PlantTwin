
using PlantTwin.Models;

namespace PlantTwin.Interfaces
{
    public interface IMachineState
    {
        string NombreEstado { get; }
        void Handle(Machine m);
    }
}
