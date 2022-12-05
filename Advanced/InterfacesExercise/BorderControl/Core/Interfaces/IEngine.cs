using BorderControl.IO.Interfaces;

namespace BorderControl.Core.Interfaces
{
    public interface IEngine
    {
        IReader Reader { get; }
        IWriter Writer { get; }

        void Run();
    }
}
