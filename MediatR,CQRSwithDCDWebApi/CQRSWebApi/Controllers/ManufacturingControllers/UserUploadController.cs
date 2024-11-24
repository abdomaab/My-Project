using Domins.Models;
using Handler.Dto;
using Handler.MediatorHandler.MediatorCommand.UserUploads;
using Handler.MediatorHandler.MediatorQuery.Products;
using Handler.MediatorHandler.MediatorQuery.UserUploads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWebApi.Controllers.ManfacturingControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUploadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserUploadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetById{id}")]
        public async ValueTask<UserUpload> GetByIdAsync(int id)
        {
            var order = new GetUserUploadByIdQuery(id);
            return await _mediator.Send(order);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async ValueTask<IEnumerable<UserUpload>> GetAllAsync()
        {
            var order = new GetAllUserUploadsQuery();
            return await _mediator.Send(order);
        }

        [HttpPost("Add")]

        public async ValueTask<UserUpload> AddAsync(UserUploadDto userUploadDto)
        {
            var order = new AddUserUploadCommand(userUploadDto);
            return await _mediator.Send(order);
        }

        [HttpPut("Update{id}")]

        public async ValueTask<UserUpload> UpdateAsync(UserUploadDto userUploadDto)
        {
            var order = new UpdateUserUploadCommand(userUploadDto);
            return await _mediator.Send(order);
        }

        [HttpDelete("Delete{id}")]

        public async ValueTask<UserUpload> DeleteAsync(int id)
        {
            var order = new DeleteUserUploadCommand(id);
            return await _mediator.Send(order);
        }
    }
}
