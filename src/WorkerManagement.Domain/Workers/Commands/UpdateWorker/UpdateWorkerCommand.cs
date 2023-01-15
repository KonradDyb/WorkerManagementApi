using MediatR;

namespace WorkerManagement.Domain.Workers.Commands.UpdateWorker;

public sealed record UpdateWorkerCommand(Guid WorkerId, string Surname, int Gender, string EvidenceNumber) : IRequest;