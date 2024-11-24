using AutoMapper;
using Domins.Models;
using Handler.MediatorHandler.MediatorCommand.Categories;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommandHndler.Categories
{
    public class DeleteCategoryValidatorHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly IUnityOfWork _unityOfWork;
        public DeleteCategoryValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var find = await _unityOfWork.Categories.GetByidAsync(request.Id);
            return await _unityOfWork.Categories.DeleteAsync(request.Id);
        }
    }
}
