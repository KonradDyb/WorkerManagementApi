using WorkerManagement.Domain.Entities;
using WorkerManagement.Domain.ValueObjects;

namespace WorkerManagement.Tests.Unit.Entities;

public static class WorkerTestsHelper
{
    public static Worker InitializeTestData(string surname, int gender, string evidenceNumber) =>
        new(WorkerId.Create(), surname, gender, evidenceNumber);
}