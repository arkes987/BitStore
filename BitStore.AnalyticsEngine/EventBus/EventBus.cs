using BitStore.Common.Interfaces.EventBus;
using Microsoft.Extensions.Logging;

namespace BitStore.AnalyticsEngine.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly ILogger<EventBus> _logger;
        public EventBus(ILogger<EventBus> logger)
        {
            _logger = logger;
        }
        public Task Publish(IEvent @event)
        {
            _logger.LogInformation($"Publishing event {@event.OccouredAt}");
            return Task.CompletedTask;
            //throw new NotImplementedException();
        }
    }
}
