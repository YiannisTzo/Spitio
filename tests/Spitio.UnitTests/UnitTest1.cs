using Spitio.Domain.Entities;

namespace Spitio.UnitTests;

public class CleaningRequestTests
{
    [Fact]
    public void NewCleaningRequest_ShouldHavePendingStatus()
    {
        // Arrange
        var id = Guid.NewGuid();
        var customerId = Guid.NewGuid();
        var propertyId = Guid.NewGuid();
        var serviceTypeId = Guid.NewGuid();
        var description = "Deep cleaning";

        // Act
        var request = new CleaningRequest(
            id,
            customerId,
            propertyId,
            serviceTypeId,
            description);

        // Assert
        Assert.Equal(id, request.Id);
        Assert.Equal(customerId, request.CustomerId);
        Assert.Equal(propertyId, request.PropertyId);
        Assert.Equal(serviceTypeId, request.ServiceTypeId);
        Assert.Equal(description, request.Description);
        Assert.Equal(CleaningRequestStatus.Pending, request.Status);
    }

    [Fact]
    public void Confirm_ShouldChangeStatusToConfirmed()
    {
        var request = CreateRequest();

        request.Confirm();

        Assert.Equal(CleaningRequestStatus.Confirmed, request.Status);
    }

    [Fact]
    public void Start_ShouldChangeStatusToInProgress()
    {
        var request = CreateRequest();

        request.Confirm();
        request.Start();

        Assert.Equal(CleaningRequestStatus.InProgress, request.Status);
    }

    [Fact]
    public void Complete_ShouldChangeStatusToCompleted()
    {
        var request = CreateRequest();

        request.Confirm();
        request.Start();
        request.Complete();

        Assert.Equal(CleaningRequestStatus.Completed, request.Status);
    }

    [Fact]
    public void CannotCompletePendingRequest()
    {
        var request = CreateRequest();

        Assert.Throws<InvalidOperationException>(
            () => request.Complete());
    }

    [Fact]
    public void CannotStartPendingRequest()
    {
        var request = CreateRequest();

        Assert.Throws<InvalidOperationException>(
            () => request.Start());
    }

    [Fact]
    public void CannotCancelCompletedRequest()
    {
        var request = CreateRequest();

        request.Confirm();
        request.Start();
        request.Complete();

        Assert.Throws<InvalidOperationException>(
            () => request.Cancel());
    }

    
    private static CleaningRequest CreateRequest()
    {
        return new CleaningRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Deep cleaning");
    }
}