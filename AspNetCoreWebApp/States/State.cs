using System.Threading;

namespace AspNetCoreWebApp.States
{
    public class State : IState
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public SemaphoreSlim ProtectedActionSemaphore { get => _semaphore; }
    }
}