using Spitio.Domain.Entities;

namespace Spitio.UnitTests;

public class CustomerTests
{
    [Fact]
    public void Customer_ShouldBeCreatedWithValidData()
    {
        var id = Guid.NewGuid();

        var customer = new Customer(
            id,
            "John",
            "Smith",
            "john@example.com");

        Assert.Equal(id, customer.Id);
        Assert.Equal("John", customer.FirstName);
        Assert.Equal("Smith", customer.LastName);
        Assert.Equal("john@example.com", customer.Email);
    }

    [Fact]
    public void Customer_ShouldRejectEmptyFirstName()
    {
        Assert.Throws<ArgumentException>(() =>
            new Customer(
                Guid.NewGuid(),
                "",
                "Smith",
                "john@example.com"));
    }

    [Fact]
    public void Customer_ShouldRejectEmptyLastName()
    {
        Assert.Throws<ArgumentException>(() =>
            new Customer(
                Guid.NewGuid(),
                "John",
                "",
                "john@example.com"));
    }

    [Fact]
    public void Customer_ShouldRejectEmptyEmail()
    {
        Assert.Throws<ArgumentException>(() =>
            new Customer(
                Guid.NewGuid(),
                "John",
                "Smith",
                ""));
    }

    [Fact]
    public void Customer_ShouldHaveNoPropertiesInitially()
    {
        var customer = new Customer(
            Guid.NewGuid(),
            "John",
            "Smith",
            "john@example.com");

        Assert.Empty(customer.Properties);
    }

    [Fact]
    public void Customer_ShouldAddProperty()
    {
        var customerId = Guid.NewGuid();

        var customer = new Customer(
            customerId,
            "John",
            "Smith",
            "john@example.com");

        var property = new Property(
            Guid.NewGuid(),
            customerId,
            "Main House",
            "123 Main Street");

        customer.AddProperty(property);

        Assert.Single(customer.Properties);
        Assert.Contains(property, customer.Properties);
    }

    [Fact]
    public void Customer_ShouldRejectPropertyBelongingToAnotherCustomer()
    {
        var customer = new Customer(
            Guid.NewGuid(),
            "John",
            "Smith",
            "john@example.com");

        var property = new Property(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Main House",
            "123 Main Street");

        Assert.Throws<InvalidOperationException>(
            () => customer.AddProperty(property));
    }

    [Fact]
    public void Customer_ShouldRejectDuplicateProperty()
    {
        var customerId = Guid.NewGuid();

        var customer = new Customer(
            customerId,
            "John",
            "Smith",
            "john@example.com");

        var propertyId = Guid.NewGuid();

        var property = new Property(
            propertyId,
            customerId,
            "Main House",
            "123 Main Street");

        var duplicateProperty = new Property(
            propertyId,
            customerId,
            "Another Name",
            "456 Another Street");

        customer.AddProperty(property);

        Assert.Throws<InvalidOperationException>(
            () => customer.AddProperty(duplicateProperty));
    }
}