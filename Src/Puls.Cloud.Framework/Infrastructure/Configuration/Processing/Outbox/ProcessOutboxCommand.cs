using MediatR;

namespace Puls.Cloud.Framework.Infrastructure.Configuration.Processing.Outbox;

public record ProcessOutboxCommand(string MessageId) : IRequest;