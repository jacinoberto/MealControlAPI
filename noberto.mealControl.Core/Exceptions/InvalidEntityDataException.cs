namespace noberto.mealControl.Core.Exceptions;

public class InvalidEntityDataException : Exception
{
    public InvalidEntityDataException(string message) 
        : base(message) {}

    public static void When(bool hasError, string message)
    {
        if (hasError) throw new InvalidEntityDataException(message);
    }
}
