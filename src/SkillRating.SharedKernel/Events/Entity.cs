namespace SkillRating.SharedKernel.Events;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public bool HasDomainEvents()
    {
        return _domainEvents.Count != 0;
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
