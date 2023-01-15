using System;
using Shouldly;
using WorkerManagement.Domain.Entities;
using WorkerManagement.Domain.ValueObjects;
using Xunit;

namespace WorkerManagement.Tests.Unit.Entities;

public class WorkerConstructorTests
{
    [Fact]
    public void given_valid_worker_id_surname_gender_and_evidenceNumber_should_create_worker_object()
    {
        // ARRANGE
        var workerId = WorkerId.Create();
        var surname = new Surname("Nowak");
        var gender = new Gender(1);
        var evidenceNumber = new EvidenceNumber("00000001");
        
        // ACT
        var worker = new Worker(workerId, surname, gender, evidenceNumber);
        
        // ASSERT

        worker.ShouldSatisfyAllConditions(
            w => w.ShouldNotBeNull(),
            w => w.Id.ShouldBe(workerId),
            w => w.Surname.ShouldBe(surname),
            w => w.Gender.ShouldBe(gender),
            w => w.EvidenceNumber.ShouldBe(evidenceNumber));
    }

    [Fact]
    public void given_null_worker_id_should_throw_exception()
    {
        // ARRANGE
        var surname = new Surname("Nowak");
        var gender = new Gender(1);
        var evidenceNumber = new EvidenceNumber("00000001");
        
        // ACT & ASSERT
        Should.Throw<Exception>(() =>
        {
            new Worker(null, surname, gender, evidenceNumber);
        });
    }

    [Fact]
    public void given_null_surname_should_throw_exception()
    {
        // ARRANGE
        var workerId = WorkerId.Create();
        var gender = new Gender(1);
        var evidenceNumber = new EvidenceNumber("00000001");
        
        // ACT & ASSERT
        Should.Throw<Exception>(() =>
        {
            new Worker(workerId, null, gender, evidenceNumber);
        });
    }

    [Fact]
    public void given_null_gender_should_throw_exception()
    {
        // ARRANGE
        var workerId = WorkerId.Create();
        var surname = new Surname("Nowak");
        var evidenceNumber = new EvidenceNumber("00000001");
        
        // ACT & ASSERT
        Should.Throw<Exception>(() =>
        {
            new Worker(workerId, surname, null, evidenceNumber);
        });
    }

    [Fact]
    public void given_null_evidenceNumber_should_throw_exception()
    {
        // ARRANGE
        var workerId = WorkerId.Create();
        var surname = new Surname("Nowak");
        var gender = new Gender(1);
        
        // ACT & ASSERT
        Should.Throw<Exception>(() =>
        {
            new Worker(workerId, surname, gender, null);
        });
    }
}