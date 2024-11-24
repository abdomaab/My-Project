using AutoMapper;
using Domins.Models;
using Handler.Dto;
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
    public class UpdateCategoryValidatorHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {

        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoryValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.Categories.GetByidAsync(request.Id);
            var category = _mapper.Map<Category>(request);
            return await _unityOfWork.Categories.UpdateAsync(category);
        }
    }
}
