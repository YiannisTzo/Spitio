namespace Spitio.Domain.Entities;

public class ServiceType
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ServiceType(
        Guid id,
        string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Service type name cannot be empty.",
                nameof(name));
        }

        Id = id;
        Name = name;
    }
}