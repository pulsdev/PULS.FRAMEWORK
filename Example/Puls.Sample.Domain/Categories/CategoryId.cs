using Puls.Cloud.Framework.Domain;

namespace Puls.Sample.Domain.Categories
{
    public class CategoryId : TypedId<Guid>
    {
        public CategoryId(Guid value) : base(value)
        {
        }
    }
}