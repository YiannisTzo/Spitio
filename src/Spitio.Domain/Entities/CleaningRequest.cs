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
                "Only pending cleaning requests can be confirmed.");

        Status = CleaningRequestStatus.Confirmed;
    }

    public void Start()
    {
        if (Status != CleaningRequestStatus.Confirmed)
            throw new InvalidOperationException(
                "Only confirmed cleaning requests can be started.");

        Status = CleaningRequestStatus.InProgress;
    }

    public void Complete()
    {
        if (Status != CleaningRequestStatus.InProgress)
            throw new InvalidOperationException(
                "Only in-progress cleaning requests can be completed.");

        Status = CleaningRequestStatus.Completed;
    }

    public void Cancel()
    {
        if (Status == CleaningRequestStatus.Completed)
            throw new InvalidOperationException(
                "Completed cleaning requests cannot be cancelled.");

        if (Status == CleaningRequestStatus.Cancelled)
            throw new InvalidOperationException(
                "Cleaning request is already cancelled.");

        Status = CleaningRequestStatus.Cancelled;
    }
}