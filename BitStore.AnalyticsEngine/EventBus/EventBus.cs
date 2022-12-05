using BitStore.Common.Interfaces.EventBus;

namespace BitStore.AnalyticsEngine.EventBus
{
    public class EventBus : IEventBus
    {
        public Task Publish(IEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
