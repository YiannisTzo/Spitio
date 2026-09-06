namespace Spitio.Domain.Entities;

public class ServiceType
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ServiceType(
        Guid id,
        string name)
    {
        Id = id;
        Name = name;
    }
}