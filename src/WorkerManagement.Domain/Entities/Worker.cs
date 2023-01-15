using WorkerManagement.Domain.ValueObjects;

namespace WorkerManagement.Domain.Entities;

public class Worker
{
    public WorkerId Id { get; }
    public Surname Surname { get; private set; }
    public Gender Gender { get; private set;}
    public EvidenceNumber EvidenceNumber { get; private set; }

    public Worker(WorkerId id, Surname surname, Gender gender, EvidenceNumber evidenceNumber)
    {
        Id = id ?? throw new Exception($"nameof{typeof(WorkerId)} is null");
        Surname = surname ?? throw new Exception($"nameof{Surname} is null");
        Gender = gender ?? throw new Exception($"nameof{Gender} is m");
        EvidenceNumber = evidenceNumber ?? throw new Exception($"nameof{EvidenceNumber} is null");
    }

    public void ChangeWorkerProperties(Surname surname, Gender gender, EvidenceNumber evidenceNumber)
    {
        Surname = surname ?? throw new Exception($"nameof{Surname} is null");
        Gender = gender ?? throw new Exception($"nameof{Gender} is null");
        EvidenceNumber = evidenceNumber ?? throw new Exception($"nameof{EvidenceNumber} is null");
    }
}