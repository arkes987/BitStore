using BitStore.Common.Interfaces.EventBus;

namespace BitStore.Common.Interfaces.Events
{
    public class ItemAccesedEvent : IEvent
    {
        public Guid ItemId { get; }

        private DateTime _occouredAt;
        public DateTime OccouredAt
        {
            get { return _occouredAt; }
            private set { _occouredAt = value; }
        }

        public ItemAccesedEvent(Guid itemId, DateTime occouredAt)
        {
            ItemId = itemId;
            _occouredAt = occouredAt;
        }
    }
}
