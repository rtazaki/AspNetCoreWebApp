using System;
using System.Threading;

namespace AspNetCoreWebApp.States
{
    public class SemaphoreUtility
    {
        private readonly IDisposable _releaser;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public SemaphoreUtility()
        {
            _releaser = new Releaser(_semaphore);
        }
        public bool IsLock()
        {
            return _semaphore.CurrentCount == 0 ? true : false;
        }
        public IDisposable Lock()
        {
            _semaphore.Wait();
            return _releaser;
        }
        private class Releaser : IDisposable
        {
            private readonly SemaphoreSlim _semaphore;
            public Releaser(SemaphoreSlim semaphore)
            {
                _semaphore = semaphore;
            }
            public void Dispose()
            {
                _semaphore.Release();
            }
        }
    }
}
