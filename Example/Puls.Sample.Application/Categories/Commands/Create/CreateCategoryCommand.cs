using Puls.Sample.Domain.Categories;
using Puls.Cloud.Framework.DirectOperations;

namespace Puls.Sample.Application.Categories.Commands.Create
{
    public record CreateCategoryCommand(
        CategoryId CategoryId,
        string Name,
        string Description) : DirectCommand<Guid>;
}