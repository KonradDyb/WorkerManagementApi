using WorkerManagement.Domain.Common.Enums;

namespace WorkerManagement.Domain.ValueObjects;

public record Gender
{
    public GenderEnum Value { get; }

    public Gender(int value)
    {
        if (!Enum.IsDefined(typeof(GenderEnum), value))
        {
            Value = default;
        }
        else
        {
            Value = (GenderEnum)value;
        }
    }
    
    public static implicit operator Gender(int value)
        => new(value);
}