using PlantTwin.Interfaces;

namespace PlantTwin.Services
{
    public class NotifierService : IObserver
    {
        public List<string> Log { get; } = new();
        public void Notify(string message)
        {
            Log.Add($"{DateTime.UtcNow}: {message}");
            Console.WriteLine(message);
        }
    }
}
