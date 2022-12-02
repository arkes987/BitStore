namespace BitStore.Common.Exceptions.Volume
{
    public class NoEnoughSpaceOnVolumeException : CustomException
    {
        public NoEnoughSpaceOnVolumeException(long requestedSpace)
            : base($"There is no enough space on volume, requested {requestedSpace}") { }
    }
}
