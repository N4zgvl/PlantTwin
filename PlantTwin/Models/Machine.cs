using PlantTwin.Interfaces;
using System.Diagnostics;

namespace PlantTwin.Models
{
    public class Machine : IMachine, ICloneable
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public IMachineState State { get; private set; }
        public IStrategy Behavior { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public int Rpm { get; set; }
        public List<EventLog> Events { get; } = new();

        private readonly List<IObserver> _observers = new();

        public Machine(string name, IMachineState initialState, IStrategy behavior)
        {
            Name = name;
            State = initialState;
            Behavior = behavior;
        }

        public void SetState(IMachineState state)
        {
            State = state;
            Events.Add(new EventLog { Timestamp = DateTime.UtcNow, Message = $"Estado -> {state.NombreEstado}" });
            NotifyObservers($"Máquina {Name}: nuevo estado {state.NombreEstado}");
        }

        public void Update()
        {
            Behavior?.Execute(this);
            State.Handle(this);
        }

        public object Clone()
        {
            return new Machine(Name + "-clone", State, Behavior)
            {
                Temperature = this.Temperature,
                Pressure = this.Pressure,
                Rpm = this.Rpm
            };
        }

        // Observer
        public void Attach(IObserver obs) => _observers.Add(obs);
        public void Detach(IObserver obs) => _observers.Remove(obs);
        private void NotifyObservers(string msg) => _observers.ForEach(o => o.Notify(msg));
    }
}
