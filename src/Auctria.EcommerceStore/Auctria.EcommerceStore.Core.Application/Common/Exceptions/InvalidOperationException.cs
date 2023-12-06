namespace Auctria.EcommerceStore.Core.Application.Common.Exceptions
{
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException() : base() { }

        public InvalidOperationException(string name, object key)
        : base($"Unable to carry out this operation - {name} ({key})")
        {
        }

        public InvalidOperationException(string? message) : base(message) { }

        public InvalidOperationException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
