namespace noberto.mealControl.Core.Exceptions;

public class ServerErrorException : Exception
{
    public ServerErrorException(string message)
        : base(message) {}
}