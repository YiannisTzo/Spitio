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
}