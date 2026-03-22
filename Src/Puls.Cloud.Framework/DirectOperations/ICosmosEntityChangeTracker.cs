using System.Collections.Generic;
using Puls.Cloud.Framework.Domain;

namespace Puls.Cloud.Framework.DirectOperations;

public interface ICosmosEntityChangeTracker
{
    void Track(CosmosEntity entity, string containerName);

    List<CosmosEntity> GetTrackedEntities();

    List<IDomainEvent> GetDomainEvents();
}