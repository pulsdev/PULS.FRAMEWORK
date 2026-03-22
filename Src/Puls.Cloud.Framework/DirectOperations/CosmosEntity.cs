using System.Collections.Generic;
using System.Threading.Tasks;
using Puls.Cloud.Framework.Domain;
using Newtonsoft.Json;

namespace Puls.Cloud.Framework.DirectOperations;

public abstract class CosmosEntity : Entity
{
    [JsonIgnore]
    public abstract TypedId Id { get; }

    [JsonProperty("_etag")]
    public string ETag { get; set; }

    [JsonIgnore]
    private readonly List<IDomainEvent> _domainEvents = new();

    [JsonIgnore]
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected abstract void Apply(IDomainEvent @event);
}