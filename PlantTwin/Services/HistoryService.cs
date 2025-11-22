using PlantTwin.Models;

namespace PlantTwin.Services
{
    public static class HistoryService
    {
        private static List<HistoryEvent> _events = new();

        public static void AddEvent(string maquina, string evento)
        {
            _events.Add(new HistoryEvent
            {
                Fecha = DateTime.Now,
                Maquina = maquina,
                Evento = evento
            });
        }

        public static List<HistoryEvent> GetAll()
        {
            return _events.OrderByDescending(e => e.Fecha).ToList();
        }
    }
}
