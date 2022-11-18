using BitStore.Common.Interfaces.Redis;
using RedLockNet;

namespace BitStore.Cache
{
    public class RedisLock : IRedisLock
    {
        private readonly IDistributedLockFactory _distributedLockFactory;
        public RedisLock(IDistributedLockFactory distributedLockFactory)
        {
            _distributedLockFactory = distributedLockFactory;
        }
        public async Task LockResource(Guid id)
        {
            var resource = "the-thing-we-are-locking-on";
            var expiry = TimeSpan.FromSeconds(30);
            var wait = TimeSpan.FromSeconds(10);
            var retry = TimeSpan.FromSeconds(1);

            // blocks until acquired or 'wait' timeout
            await using (var redLock = await _distributedLockFactory.CreateLockAsync(resource, expiry, wait, retry)) // there are also non async Create() methods
            {
                // make sure we got the lock
                if (redLock.IsAcquired)
                {
                    // do stuff
                }
            }
            throw new NotImplementedException();
        }
    }
}
