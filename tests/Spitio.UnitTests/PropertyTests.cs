using Spitio.Domain.Entities;

namespace Spitio.UnitTests;

public class PropertyTests
{
    [Fact]
    public void Property_ShouldBeCreatedWithValidData()
    {
        var id = Guid.NewGuid();
        var customerId = Guid.NewGuid();

        var property = new Property(
            id,
            customerId,
            "Main House",
            "123 Main Street");

        Assert.Equal(id, property.Id);
        Assert.Equal(customerId, property.CustomerId);
        Assert.Equal("Main House", property.Name);
        Assert.Equal("123 Main Street", property.Address);
    }

    [Fact]
    public void Property_ShouldRejectEmptyCustomerId()
    {
        Assert.Throws<ArgumentException>(() =>
            new Property(
                Guid.NewGuid(),
                Guid.Empty,
                "Main House",
                "123 Main Street"));
    }

    [Fact]
    public void Property_ShouldRejectEmptyName()
    {
        Assert.Throws<ArgumentException>(() =>
            new Property(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "",
                "123 Main Street"));
    }

    [Fact]
    public void Property_ShouldRejectEmptyAddress()
    {
        Assert.Throws<ArgumentException>(() =>
            new Property(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "Main House",
                ""));
    }
}