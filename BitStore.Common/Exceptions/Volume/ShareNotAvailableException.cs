namespace BitStore.Common.Exceptions.Volume
{
    public class ShareNotAvailableException : CustomException
    {
        public ShareNotAvailableException(string share) : base($"Share {share} is not available.") { }
    }
}
