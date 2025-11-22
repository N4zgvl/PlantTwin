using PlantTwin.Models;
using PlantTwin.Patterns.State;

namespace PlantTwin.Patterns.Command
{
    public class StartCommand : ICommand
    {
        private readonly Machine _m;
        public StartCommand(Machine m) => _m = m;
        public void Execute() => _m.SetState(new EncendidaState());
    }
}
