using System;

namespace Puls.Cloud.Framework.Application.Exceptions;

public class InconsistencyException : Exception
{
    public InconsistencyException(string message)
        : base(message)
    {
    }
}
