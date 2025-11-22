using PlantTwin.Models;
using PlantTwin.Patterns.State;
using PlantTwin.Patterns.Strategy;

namespace PlantTwin.Services
{
    public static class MachineFactory
    {
        public static Machine Create(string type, string name)
        {
            var behavior = type == "heavy" ? (PlantTwin.Interfaces.IStrategy)new OverloadBehavior() : new NormalBehavior();
            return new Machine(name, new ApagadaState(), behavior);
        }

        public static Machine Clone(Machine prototype) => (Machine)prototype.Clone();
    }
}
