using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Cloud.Framework.Infrastructure.Configuration.Processing.InternalCommands;

public record FailInternalCommand : Command
{
    public FailInternalCommand(string messageId, string? errorMessage)
    {
        MessageId = messageId;
        ErrorMessage = errorMessage;
    }

    public string MessageId { get; }
    public string? ErrorMessage { get; }
}