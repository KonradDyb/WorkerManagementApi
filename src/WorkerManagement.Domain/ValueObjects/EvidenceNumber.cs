namespace WorkerManagement.Domain.ValueObjects;

public class EvidenceNumber
{
    public string Value { get; }

    public EvidenceNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exception($"{nameof(EvidenceNumber)} is null or whitespace");
        }

        if (value.Length is < 1 or > 8)
        {
            throw new Exception($"{nameof(EvidenceNumber)} exceed the length");
        }

        Value = value;
    }

    public static implicit operator string(EvidenceNumber surname)
        => surname.Value;
    
    public static implicit operator EvidenceNumber(string value)
        => new(value);
}