namespace XFrame.Aggregates.Commands.Exceptions
{
    public class NoCommandHandlersException : Exception
    {
        public NoCommandHandlersException(string message) : base(message)
        {
        }
    }
}
