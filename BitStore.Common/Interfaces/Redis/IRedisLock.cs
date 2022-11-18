namespace BitStore.Common.Interfaces.Redis
{
    public interface IRedisLock
    {
        Task LockResource(Guid id);
    }
}
