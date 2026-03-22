using System;

namespace Puls.Cloud.Framework.Infrastructure.RetryPolicy;

public class PollyConfig
{
    public TimeSpan[] SleepDurations { get; set; }
}
