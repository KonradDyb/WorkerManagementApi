using Microsoft.AspNetCore.Mvc;
using WorkerManagement.Domain.Workers.Commands.CreateWorker;
using WorkerManagement.Domain.Workers.Commands.UpdateWorker;

namespace WorkerManagement.Api.Controllers;

[Route("workers")]
public class WorkerController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreateWorkerCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<ActionResult> Put(UpdateWorkerCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
}