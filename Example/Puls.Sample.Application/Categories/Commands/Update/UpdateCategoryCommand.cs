using Puls.Sample.Domain.Categories;
using Puls.Cloud.Framework.DirectOperations;

namespace Puls.Sample.Application.Categories.Commands.Update
{
    public record UpdateCategoryCommand(
        CategoryId CategoryId,
        string Name,
        string Description,
        CategoryTag Tag) : DirectCommand;
}