namespace Spitio.Domain.Entities;

public class CleaningRequest
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public Guid PropertyId { get; private set; }

    public string Description { get; private set; }

    public Guid ServiceTypeId { get; private set; }

    public CleaningRequestStatus Status { get; private set; }

    public CleaningRequest(
        Guid id,
        Guid customerId,
        Guid propertyId,
        Guid serviceTypeId,
        string description)
    {
        Id = id;
        CustomerId = customerId;
        PropertyId = propertyId;
        ServiceTypeId = serviceTypeId;
        Description = description;
        Status = CleaningRequestStatus.Pending;
    }
}