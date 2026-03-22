using Puls.Cloud.Framework.Domain;
using Newtonsoft.Json;

namespace Puls.Sample.Domain.Categories
{
    public class CategoryTag : ValueObject
    {
        public string Title { get; } = null!;

        private CategoryTag()
        {
        }

        [JsonConstructor]
        private CategoryTag(string title)
        {
            Title = title;
        }

        public static CategoryTag Create(string title)
        {
            return new CategoryTag(title);
        }
    }
}