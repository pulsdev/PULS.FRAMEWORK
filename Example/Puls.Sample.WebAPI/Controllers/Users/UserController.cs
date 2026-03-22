using Puls.Sample.API.Controllers.Categories.Requests;
using Puls.Sample.Application.Categories.Commands.Create;
using Puls.Sample.Application.Categories.Queries.Dto;
using Puls.Sample.Application.Categories.Queries.GetCategories;
using Puls.Sample.Domain.Categories;
using Puls.Cloud.Framework.Application.Contracts;
using Puls.Cloud.Framework.Authentication.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Puls.Sample.API.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = SwaggerUiExtension.PublicApiGroup)]
    public class UserController : ControllerBase
    {
        private readonly IServiceModule _serviceModule;

        public UserController(IServiceModule serviceModule)
        {
            _serviceModule = serviceModule;
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Category Id</returns>
        [HttpPost]
        [PulsAuthorize(PulsPolicyNames.EntraExternalIdOnly)]
        [ProducesResponseType(typeof(Guid), statusCode: 200)]
        public async Task<IActionResult> CreateCategory(
            [FromBody] CreateCategoryRequest request)
        {
            var categoryId = await _serviceModule.ExecuteCommandAsync(
                    new CreateCategoryCommand(
                        new CategoryId(Guid.NewGuid()),
                        request.Name,
                        request.Description)
                );

            return Ok(categoryId);
        }

        /// <summary>
        /// Retrieves a paginated list of categories.
        /// </summary>
        /// <param name="pageNumber">page number</param>
        /// <param name="pageSize">page size</param>
        /// <returns>Category List</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedDto<CategoryQueryDto>), statusCode: 200)]
        public async Task<IActionResult> GetCategories(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            var queryDto = await _serviceModule.ExecuteQueryAsync(
                new GetCategoriesQuery(
                    pageNumber,
                    pageSize
                ));

            return Ok(queryDto);
        }
    }
}