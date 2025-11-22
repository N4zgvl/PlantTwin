using PlantTwin.Interfaces;
using PlantTwin.Models;
using PlantTwin.Patterns.State;

namespace PlantTwin.Patterns.Strategy
{
    public class OverloadBehavior : IStrategy
    {
        public void Execute(Machine m)
        {
            m.Temperature += 1.0;
            m.Rpm += 25;
            if (m.Temperature > 90)
                m.SetState(new FalloState());
        }
    }
}
