using System;

namespace Puls.Cloud.Framework.Application;

public interface IServiceContextAccessor
{
    Guid UserId { get; }

    string FirstName { get; }
    string LastName { get; }
    string EmailAddress { get; }

    string UserName { get; }

    Guid UserObjectId { get; }
}