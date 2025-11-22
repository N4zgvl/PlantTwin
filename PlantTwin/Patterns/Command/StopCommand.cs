using PlantTwin.Models;
using PlantTwin.Patterns.State;

namespace PlantTwin.Patterns.Command
{
    public class StopCommand : ICommand
    {
        private readonly Machine _m;
        public StopCommand(Machine m) => _m = m;
        public void Execute() => _m.SetState(new ApagadaState());
    }
}
