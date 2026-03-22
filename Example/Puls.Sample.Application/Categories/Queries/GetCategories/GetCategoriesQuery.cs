using Puls.Sample.Application.Categories.Queries.Dto;
using Puls.Cloud.Framework.Application.Contracts;

namespace Puls.Sample.Application.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery(
        int PageNumber,
        int PageSize) : PageableQuery<CategoryQueryDto>(PageNumber, PageSize);
}