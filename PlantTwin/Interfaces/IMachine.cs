using PlantTwin.Models;

namespace PlantTwin.Interfaces
{
    public interface IMachine
    {
        void Update();
        void SetState(IMachineState state);
    }
}
