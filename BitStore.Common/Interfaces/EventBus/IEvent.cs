namespace BitStore.Common.Interfaces.EventBus
{
    public interface IEvent
    {
        public DateTime OccouredAt { get; }
    }
}
