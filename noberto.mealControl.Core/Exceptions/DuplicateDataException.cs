namespace noberto.mealControl.Core.Exceptions;

public class DuplicateDataException : Exception
{
    public DuplicateDataException(string message)
        : base(message) { }

    public DuplicateDataException(string message, string value)
        : base($"{message}: {value}") {}
}
