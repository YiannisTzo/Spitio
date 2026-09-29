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
        if (propertyId == Guid.Empty)
        {
            throw new ArgumentException(
                "PropertyId is required.",
                nameof(propertyId));
        }

        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException(
                "Photo URL is required.",
                nameof(url));
        }

        Id = id;
        PropertyId = propertyId;
        Url = url;
    }
}