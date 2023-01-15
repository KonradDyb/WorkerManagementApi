using System;
using Shouldly;
using WorkerManagement.Domain.ValueObjects;
using Xunit;

namespace WorkerManagement.Tests.Unit.Entities;

public class WorkerUpdateMethodTests
{
    private readonly Surname _newSurname = new("Kowalski");
    private readonly Gender _newGender = new(2);
    private readonly EvidenceNumber _newEvidenceNumber = new("00000002");
    
    [Fact]
    public void given_valid_surname_gender_and_evidenceNumber_should_update_worker_properties()
    {
        // ARRANGE
        var worker = WorkerTestsHelper.InitializeTestData("Nowak", 1, "00000001");
        
        // ACT
        worker.ChangeWorkerProperties(_newSurname, _newGender, _newEvidenceNumber);
        
        // ASSERT
        worker.ShouldSatisfyAllConditions(
            w => w.Surname.ShouldBe(_newSurname),
            w => w.Gender.ShouldBe(_newGender),
            w => w.EvidenceNumber.ShouldBe(_newEvidenceNumber));
    }

    [Fact]
    public void given_null_surname_should_throw_exception()
    {
        // ARRANGE
        var worker = WorkerTestsHelper.InitializeTestData("Nowak", 1, "00000001");
        
        // ACT & ASSERT
        Should.Throw<Exception>(() =>
        {
            worker.ChangeWorkerProperties(null, _newGender, _newEvidenceNumber);
        });
    }
    
    [Fact]
    public void given_null_gender_should_throw_exception()
    {
        // ARRANGE
        var worker = WorkerTestsHelper.InitializeTestData("Nowak", 1, "00000001");
        
        // ACT & ASSERT
        Should.Throw<Exception>(() =>
        {
            worker.ChangeWorkerProperties(_newSurname, null, _newEvidenceNumber);
        });
    }
    
    [Fact]
    public void given_null_evidenceNumber_should_throw_exception()
    {
        // ARRANGE
        var worker = WorkerTestsHelper.InitializeTestData("Nowak", 1, "00000001");
        
        // ACT & ASSERT
        Should.Throw<Exception>(() =>
        {
            worker.ChangeWorkerProperties(_newSurname, _newGender, null);
        });
    }
}
