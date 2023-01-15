using MediatR;

namespace WorkerManagement.Domain.Workers.Commands.CreateWorker;

public sealed record CreateWorkerCommand(string Surname, int Gender) : IRequest<Guid>;