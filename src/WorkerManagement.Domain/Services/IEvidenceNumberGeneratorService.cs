namespace WorkerManagement.Domain.Services;

public interface IEvidenceNumberGeneratorService
{
    public Task<string> GenerateEvidenceNumber();
}