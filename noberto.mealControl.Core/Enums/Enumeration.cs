using System.Reflection;

namespace noberto.mealControl.Core.Enums;

public class Enumeration : IComparable
{
    public double Identifier { get; private set; }
    public string Description { get; private set; }

    protected Enumeration(double identifier, string description) =>
        (Identifier, Description) = (identifier, description);

    protected Enumeration(string description) =>
        (Description) = (description);

    public override string ToString() => Description;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        return obj is Enumeration enumeration &&
               Identifier == enumeration.Identifier;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Identifier);
    }

    public int CompareTo(object other) =>
        Identifier.CompareTo(((Enumeration)other).Identifier);
}
