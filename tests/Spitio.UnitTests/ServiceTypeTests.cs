using Spitio.Domain.Entities;

namespace Spitio.UnitTests;

public class ServiceTypeTests
{
    [Fact]
    public void ServiceType_ShouldBeCreatedWithValidData()
    {
        var id = Guid.NewGuid();

        var serviceType = new ServiceType(
            id,
            "Deep Cleaning");

        Assert.Equal(id, serviceType.Id);
        Assert.Equal("Deep Cleaning", serviceType.Name);
    }

    [Fact]
    public void ServiceType_ShouldRejectEmptyName()
    {
        Assert.Throws<ArgumentException>(() =>
            new ServiceType(
                Guid.NewGuid(),
                ""));
    }

    [Fact]
    public void ServiceType_ShouldRejectWhitespaceName()
    {
        Assert.Throws<ArgumentException>(() =>
            new ServiceType(
                Guid.NewGuid(),
                "   "));
    }
}