namespace Dojo.Bakery.BuildingBlocks.CustomExceptions
{
    public class DatabaseUpdateException : Exception
    {
        public DatabaseUpdateException()
        {
        }

        public DatabaseUpdateException(string? message) : base(message)
        {
        }

        public DatabaseUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
