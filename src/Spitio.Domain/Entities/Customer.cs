namespace Spitio.Domain.Entities;

public class Customer
{
    private readonly List<Property> _properties = new();

    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public IReadOnlyCollection<Property> Properties => _properties.AsReadOnly();

    public Customer(
        Guid id,
        string firstName,
        string lastName,
        string email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException(
                "First name cannot be empty.",
                nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException(
                "Last name cannot be empty.",
                nameof(lastName));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException(
                "Email cannot be empty.",
                nameof(email));
        }

        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public void AddProperty(Property property)
    {
        if (property is null)
        {
            throw new ArgumentNullException(nameof(property));
        }

        if (property.CustomerId != Id)
        {
            throw new InvalidOperationException(
                "Property does not belong to this customer.");
        }

        if (_properties.Any(p => p.Id == property.Id))
        {
            throw new InvalidOperationException(
                "Property has already been added to this customer.");
        }

        _properties.Add(property);
    }
}