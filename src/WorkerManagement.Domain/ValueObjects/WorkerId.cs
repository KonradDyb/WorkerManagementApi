namespace WorkerManagement.Domain.ValueObjects;

public record WorkerId
{
    public Guid Value { get; }

    public WorkerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new Exception("Guid is empty");
        }
        
        Value = value;
    }

    public static WorkerId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(WorkerId parkingSpotId)
        => parkingSpotId.Value;

    public static implicit operator WorkerId(Guid value)
        => new(value);

}