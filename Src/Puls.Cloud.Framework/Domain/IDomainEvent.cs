using System;
using MediatR;

namespace Puls.Cloud.Framework.Domain;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
    string AggregateId { get; }
}