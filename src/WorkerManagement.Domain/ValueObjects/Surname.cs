namespace WorkerManagement.Domain.ValueObjects;

public record Surname
{
    public string Value { get; }

    public Surname(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception($"{nameof(Surname)} is null or whitespace");
        }

        if (value.Length is < 1 or > 50)
        {
            throw new Exception($"{nameof(Surname)} exceed the length");
        }

        Value = value;
    }

    public static implicit operator string(Surname surname)
        => surname.Value;
    
    public static implicit operator Surname(string value)
        => new(value);
}