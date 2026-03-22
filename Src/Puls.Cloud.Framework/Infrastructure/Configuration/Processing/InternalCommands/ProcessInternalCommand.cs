using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Cloud.Framework.Infrastructure.Configuration.Processing.InternalCommands;

public record ProcessInternalCommand : Command
{
    public ProcessInternalCommand(string messageId)
    {
        MessageId = messageId;
    }

    public string MessageId { get; }
}