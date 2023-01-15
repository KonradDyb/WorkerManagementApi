using WorkerManagement.Domain.Entities;
using WorkerManagement.Domain.ValueObjects;

namespace WorkerManagement.Domain.Repositories;

public interface IWorkerRepository
{
    Task Add(Worker worker);
    Task Update(Worker worker);
    Task<Worker> Get(WorkerId id);
    Task<string> GetLastWorkerEvidenceNumber();
}