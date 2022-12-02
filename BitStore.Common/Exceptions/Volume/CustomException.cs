namespace BitStore.Common.Exceptions.Volume
{
    public abstract class CustomException : Exception
    {
        protected CustomException(string message) : base(message) { }
    }
}
