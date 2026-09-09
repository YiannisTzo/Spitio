namespace Spitio.Domain.Entities;

public class CleaningRequest
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public Guid PropertyId { get; private set; }

    public Guid ServiceTypeId { get; private set; }

    public string Description { get; private set; }

    public CleaningRequestStatus Status { get; private set; }

    public CleaningRequest(
        Guid id,
        Guid customerId,
        Guid propertyId,
        Guid serviceTypeId,
        string description)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Cleaning request Id is required.");

        if (customerId == Guid.Empty)
            throw new ArgumentException("CustomerId is required.");

        if (propertyId == Guid.Empty)
            throw new ArgumentException("PropertyId is required.");

        if (serviceTypeId == Guid.Empty)
            throw new ArgumentException("ServiceTypeId is required.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Cleaning request description is required.");

        Id = id;
        CustomerId = customerId;
        PropertyId = propertyId;
        ServiceTypeId = serviceTypeId;
        Description = description;
        Status = CleaningRequestStatus.Pending;
    }

    public void Confirm()
    {
        if (Status != CleaningRequestStatus.Pending)
            throw new InvalidOperationException(
                "Only pending requests can be confirmed.");

        Status = CleaningRequestStatus.Confirmed;
    }

    public void Start()
    {
        if (Status != CleaningRequestStatus.Confirmed)
            throw new InvalidOperationException(
                "Only confirmed requests can be started.");

        Status = CleaningRequestStatus.InProgress;
    }

    public void Complete()
    {
        if (Status != CleaningRequestStatus.InProgress)
            throw new InvalidOperationException(
                "Only requests in progress can be completed.");

        Status = CleaningRequestStatus.Completed;
    }

    public void Cancel()
    {
        if (Status == CleaningRequestStatus.Completed)
            throw new InvalidOperationException(
                "Completed requests cannot be cancelled.");

        if (Status == CleaningRequestStatus.Cancelled)
            throw new InvalidOperationException(
                "Request is already cancelled.");

        Status = CleaningRequestStatus.Cancelled;
    }
}