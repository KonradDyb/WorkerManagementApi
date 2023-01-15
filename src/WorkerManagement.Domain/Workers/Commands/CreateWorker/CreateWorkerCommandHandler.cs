using MediatR;
using WorkerManagement.Domain.Entities;
using WorkerManagement.Domain.Repositories;
using WorkerManagement.Domain.Services;
using WorkerManagement.Domain.ValueObjects;

namespace WorkerManagement.Domain.Workers.Commands.CreateWorker;

public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, Guid>
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IEvidenceNumberGeneratorService _evidenceNumberGeneratorService;

    public CreateWorkerCommandHandler(
        IWorkerRepository workerRepository, 
        IEvidenceNumberGeneratorService evidenceNumberGeneratorService)
    {
        _workerRepository = workerRepository;
        _evidenceNumberGeneratorService = evidenceNumberGeneratorService;
    }
    
    public async Task<Guid> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var (surname, gender) = request;
        var evidenceNumber = await _evidenceNumberGeneratorService.GenerateEvidenceNumber();
        var worker = new Worker(WorkerId.Create(), surname, gender, evidenceNumber);

        await _workerRepository.Add(worker);
        
        return worker.Id;
    }
}