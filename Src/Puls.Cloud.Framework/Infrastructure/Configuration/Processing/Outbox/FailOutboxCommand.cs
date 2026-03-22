using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Cloud.Framework.Infrastructure.Configuration.Processing.Outbox;

public record FailOutboxCommand : Command
{
    public FailOutboxCommand(string outboxMessageId, string? errorMessage)
    {
        MessageId = outboxMessageId;
        ErrorMessage = errorMessage;
    }

    public string MessageId { get; }
    public string? ErrorMessage { get; }
}