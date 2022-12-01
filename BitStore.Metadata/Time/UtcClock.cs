using BitStore.Common.Interfaces.Time;

namespace BitStore.Metadata.Time
{
    internal class UtcClock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;
    }
}
