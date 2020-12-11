using System.Threading;

namespace AspNetCoreWebApp.States
{
    public interface IState
    {
        public SemaphoreSlim ProtectedActionSemaphore { get; }
    }
}