using Moq;
using FluentAssertions;
using TrackMyJob.Domain.Infrastructure;
using TrackMyJob.Domain.Models;
using TrackMyJob.Domain.Repos;
using TrackMyJob.Domain.Services;
namespace TrackMyJob.Domain.Tests;

[TestClass]
public class JobApplierTests
{
    [TestMethod]
    public async Task GivenCleanSlate_WhenApplying_ThenShouldSucceed()
    {
        // ARRANGE
        var ticksNow = DateTimeOffset.UtcNow.Ticks;
        JobApplication? createdApplication = null;
        var clockStub = createClockStub(ticksNow);
        var jobAppRepo = new Mock<IJobApplicationRepo>();
        jobAppRepo
            .Setup(x => x.Insert(It.IsAny<JobApplication>()))
            .Callback<JobApplication>(x => createdApplication = x)
            .ReturnsAsync(Guid.NewGuid().ToString());
        var sut = new JobApplier(jobAppRepo.Object, clockStub);

        // ACT
        var newId = await sut.Apply(companyName: "aaa", positionTitle: "bbb");

        // ASSERT
        newId.Should().NotBeNullOrWhiteSpace();
        createdApplication.Should().NotBeNull();
        createdApplication.AppliedAtUtcTicks.Should().Be(ticksNow);
    }

    static IClock createClockStub(long ticksToReturn)
    {
        var clockStub = new Mock<IClock>();
        clockStub
            .Setup(x => x.GetUtcTicks())
            .Returns(ticksToReturn);

        return clockStub.Object;
    }

}