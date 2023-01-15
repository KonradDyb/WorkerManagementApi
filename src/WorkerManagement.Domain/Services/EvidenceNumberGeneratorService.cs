using WorkerManagement.Domain.Repositories;

namespace WorkerManagement.Domain.Services;

public class EvidenceNumberGeneratorService : IEvidenceNumberGeneratorService
{
    private const string Prefix = "0000000";
    private const string DecimalFormatSpecifier = "D8";
    private readonly IWorkerRepository _workerRepository;

    public EvidenceNumberGeneratorService(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<string> GenerateEvidenceNumber()
    {
        var lastWorkerEvidenceNumber = await _workerRepository.GetLastWorkerEvidenceNumber();
        var numericPart = GetNumericPart(lastWorkerEvidenceNumber);

        numericPart++;

        return numericPart.ToString(DecimalFormatSpecifier);
    }

    private int GetNumericPart(string lastWorkerEvidenceNumber)
    {
        return string.IsNullOrWhiteSpace(lastWorkerEvidenceNumber)
            ? int.Parse(Prefix)
            : int.Parse(lastWorkerEvidenceNumber);
    }
}