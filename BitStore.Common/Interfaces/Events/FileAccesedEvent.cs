using BitStore.Common.Interfaces.EventBus;

namespace BitStore.Common.Interfaces.Events
{
    public class ItemAccesedEvent : IEvent
    {
        private Guid _itemId;
        public ItemAccesedEvent(Guid itemId)
        {
            _itemId = itemId;
        }

        public DateTime OccouredAt => throw new NotImplementedException();
    }
}
