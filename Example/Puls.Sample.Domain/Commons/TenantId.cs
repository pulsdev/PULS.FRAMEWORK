using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.Domain.Commons
{
    public class TenantId : TypedId<Guid>
    {
        public TenantId(Guid value) : base(value)
        {
        }
    }
}