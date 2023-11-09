using MediatR;

namespace MicroServiceName.Dom.Seed;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
        IsActive = true;
        _domainEvents = [];
    }

    public virtual Guid Id { get; protected set; }
    public bool IsActive { get; private set; }

    private readonly List<INotification> _domainEvents;

    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    public void OnDelete()
    {
        IsActive = false;
    }

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}