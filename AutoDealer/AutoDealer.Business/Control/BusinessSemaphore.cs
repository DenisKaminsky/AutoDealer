using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDealer.Business.Control
{
    public class BusinessSemaphore : IDisposable
    {
        private readonly SemaphoreSlim _semaphore;

        public BusinessSemaphore(int initialCount, int maxCount)
        {
            _semaphore = new SemaphoreSlim(initialCount, maxCount);
        }

        public async Task<BusinessSemaphore> LockAsync()
        {
            await _semaphore.WaitAsync();
            return this;
        }

        public void Dispose()
        {
            _semaphore.Release();
        }
    }
}
