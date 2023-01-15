using MediatR;
using WorkerManagement.Domain.Repositories;

namespace WorkerManagement.Domain.Workers.Commands.UpdateWorker;

public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand>
{
    private readonly IWorkerRepository _workerRepository;

    public UpdateWorkerCommandHandler(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<Unit> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
    {
        var exisitingWorker = await _workerRepository.Get(request.WorkerId);
        
        if (exisitingWorker is null)
        {
            throw new Exception($"Not found specific worker: {request.WorkerId}");
        }

        exisitingWorker.ChangeWorkerProperties(request.Surname, request.Gender, request.EvidenceNumber);
        
        return Unit.Value;
    }
}