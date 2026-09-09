namespace Spitio.Domain.Entities;

public class Property
{
    private readonly List<CleaningRequest> _cleaningRequests = new();
    private readonly List<PropertyPhoto> _photos = new();

    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public string Name { get; private set; }

    public string Address { get; private set; }

    public IReadOnlyCollection<CleaningRequest> CleaningRequests =>
        _cleaningRequests.AsReadOnly();

    public IReadOnlyCollection<PropertyPhoto> Photos =>
        _photos.AsReadOnly();

    public Property(
        Guid id,
        Guid customerId,
        string name,
        string address)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Property Id is required.");

        if (customerId == Guid.Empty)
            throw new ArgumentException("CustomerId is required.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property name is required.");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Property address is required.");

        Id = id;
        CustomerId = customerId;
        Name = name;
        Address = address;
    }

    public void AddCleaningRequest(CleaningRequest cleaningRequest)
    {
        if (cleaningRequest is null)
            throw new ArgumentNullException(nameof(cleaningRequest));

        if (cleaningRequest.PropertyId != Id)
            throw new InvalidOperationException(
                "Cleaning request does not belong to this property.");

        if (_cleaningRequests.Any(x => x.Id == cleaningRequest.Id))
            throw new InvalidOperationException(
                "Cleaning request has already been added to this property.");

        _cleaningRequests.Add(cleaningRequest);
    }

    public void AddPhoto(PropertyPhoto photo)
    {
        if (photo is null)
            throw new ArgumentNullException(nameof(photo));

        if (photo.PropertyId != Id)
            throw new InvalidOperationException(
                "Photo does not belong to this property.");

        if (_photos.Any(x => x.Id == photo.Id))
            throw new InvalidOperationException(
                "Photo has already been added to this property.");

        if (_photos.Count >= 3)
            throw new InvalidOperationException(
                "A property cannot have more than 3 photos.");

        _photos.Add(photo);
    }
}