using System.Security.Cryptography;

namespace PlantTwin.Patterns.Command
{
    public interface ICommand
    {
        void Execute();
    }
}
