using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Shouldly;
using WorkerManagement.Domain.Common.Enums;
using WorkerManagement.Domain.Entities;
using WorkerManagement.Domain.Repositories;
using WorkerManagement.Domain.ValueObjects;
using WorkerManagement.Domain.Workers.Commands.UpdateWorker;
using Xunit;

namespace WorkerManagement.Tests.Unit.Handlers;

public class UpdateWorkerCommandHandlerTests
{
    [Fact]
    public async Task UpdateWorkerCommand_ShouldUpdateWorker()
    {
        // ARRANGE
        var workerId = WorkerId.Create();
        var surname = "Smith";
        var gender = 2;
        var evidenceNumber = "12345";
        
        var request = new UpdateWorkerCommand(workerId.Value, surname, (int)GenderEnum.Female, evidenceNumber);
        var existingWorker = new Worker(workerId, "Johnson", (int)GenderEnum.Female, "54321");
        var workerRepositoryMock = new Mock<IWorkerRepository>();
        workerRepositoryMock.Setup(x => x.Get(workerId)).ReturnsAsync(existingWorker);
        var handler = new UpdateWorkerCommandHandler(workerRepositoryMock.Object);

        // ACT
        var result = await handler.Handle(request, CancellationToken.None);

        // ASSERT
        result.ShouldBeOfType<MediatR.Unit>();
        existingWorker.Surname.Value.ShouldBe(surname);
        existingWorker.Gender.ShouldBe(gender);
        existingWorker.EvidenceNumber.Value.ShouldBe(evidenceNumber);
        workerRepositoryMock.Verify(x => x.Get(workerId), Times.Once);
    }
    
    [Fact]
    public async Task UpdateWorkerCommand_ShouldFail()
    {
        // ARRANGE
        var workerId = WorkerId.Create();
        var surname = "Smith";
        var gender = 2;
        var evidenceNumber = "12345";
        
        var request = new UpdateWorkerCommand(workerId.Value, surname, (int)GenderEnum.Female, evidenceNumber);
        var workerRepositoryMock = new Mock<IWorkerRepository>();
        workerRepositoryMock.Setup(x => x.Get(WorkerId.Create())).Returns(Task.FromResult<Worker>(null));
        var handler = new UpdateWorkerCommandHandler(workerRepositoryMock.Object);

        // ACT & ASSERT
        await handler.Handle(request, CancellationToken.None).ShouldThrowAsync<Exception>();;
    }
}