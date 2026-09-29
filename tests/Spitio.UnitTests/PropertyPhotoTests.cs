namespace Spitio.Domain.Entities;

public class PropertyPhoto
{
    public Guid Id { get; private set; }

    public Guid PropertyId { get; private set; }

    public string Url { get; private set; }

    public PropertyPhoto(
        Guid id,
        Guid propertyId,
        string url)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Photo Id is required.");

        if (propertyId == Guid.Empty)
            throw new ArgumentException("PropertyId is required.");

        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("Photo URL is required.");

        Id = id;
        PropertyId = propertyId;
        Url = url;
    }
}