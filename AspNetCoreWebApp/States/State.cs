using System.Threading;

namespace AspNetCoreWebApp.States
{
    public class State
    {
        public readonly AsyncLock asyncLock = new AsyncLock();
    }
}