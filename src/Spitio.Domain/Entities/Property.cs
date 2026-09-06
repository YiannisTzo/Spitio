namespace Spitio.Domain.Entities;

public class Property
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public string Name { get; private set; }

    public string Address { get; private set; }

    public Property(
        Guid id,
        Guid customerId,
        string name,
        string address)
    {
        Id = id;
        CustomerId = customerId;
        Name = name;
        Address = address;
    }
}