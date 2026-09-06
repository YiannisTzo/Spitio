namespace Spitio.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public Customer(
        Guid id,
        string firstName,
        string lastName,
        string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}