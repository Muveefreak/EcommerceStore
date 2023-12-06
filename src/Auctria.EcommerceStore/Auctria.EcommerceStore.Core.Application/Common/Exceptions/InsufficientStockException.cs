namespace Auctria.EcommerceStore.Core.Application.Common.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException() : base() { }

        public InsufficientStockException(string name, object key)
        : base($"Insufficent quantity - {name} ({key})")
        {
        }

        public InsufficientStockException(string? message) : base(message) { }

        public InsufficientStockException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
