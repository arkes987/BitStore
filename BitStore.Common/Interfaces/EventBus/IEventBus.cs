namespace BitStore.Common.Interfaces.EventBus
{
    public interface IEventBus
    {
        Task Publish(IEvent @event);
    }
}
