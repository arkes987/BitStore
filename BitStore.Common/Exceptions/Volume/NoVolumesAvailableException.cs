namespace BitStore.Common.Exceptions.Volume
{
    public class NoVolumesAvailableException : CustomException
    {
        public NoVolumesAvailableException() : base("There are no available volumes") { }
    }
}
