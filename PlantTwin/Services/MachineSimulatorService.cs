using PlantTwin.Models;

namespace PlantTwin.Services
{
    public class MachineSimulatorService
    {
        private readonly List<(Machine machine, CancellationTokenSource cts)> _running = new();

        public Task StartSimulationAsync(Machine machine)
        {
            var cts = new CancellationTokenSource();
            _running.Add((machine, cts));
            return Task.Run(async () =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    machine.Update();
                    await Task.Delay(1000, cts.Token);
                }
            }, cts.Token);
        }

        public void StopSimulation(Machine machine)
        {
            var item = _running.FirstOrDefault(x => x.machine == machine);
            item.cts?.Cancel();
            _running.Remove(item);
        }
    }
}
