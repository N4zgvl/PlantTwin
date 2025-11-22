using PlantTwin.Interfaces;
using PlantTwin.Models;

namespace PlantTwin.Patterns.Strategy
{
    public class NormalBehavior : IStrategy
    {
        public void Execute(Machine m)
        {
            m.Temperature += 0.2;
            m.Rpm += 8;
        }
    }
}
