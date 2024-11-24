using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.Categories;
using Handler.MediatorHandler.MediatorQuery.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRSWebApi.Controllers.ManfacturingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetById{id}")]
        public async ValueTask<Category> GetByIdAsync(int id)
        {
            var category = new GetCategoryByIdQuery(id);
            return await _mediator.Send(category);
           
        }
        [HttpGet("GetAll")]
        public async ValueTask<IEnumerable<Category>> GetAllAsync()
        {
            var category = new GetAllCategoriesQuery();
            return (IEnumerable<Category>)await _mediator.Send(category);

        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("Add")]

        public async ValueTask<Category> AddAsync(CategoryDto categoryDto)
        {
            var category = new AddCategoryCommand(categoryDto);
            return await _mediator.Send(category);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("Update{id}")]

        public async ValueTask<Category> UpdateAsync( CategoryDto categoryDto)
        {

            var category = new UpdateCategoryCommand(categoryDto);
            return await _mediator.Send(category);
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("Delete{id}")]

        public async ValueTask<Category> DeleteAsync(int id)
        {

            var category = new DeleteCategoryCommand(id);
            return await _mediator.Send(category);
        }
    }
}
