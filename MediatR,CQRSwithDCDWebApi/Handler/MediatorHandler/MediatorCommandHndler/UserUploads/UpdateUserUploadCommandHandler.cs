﻿using AutoMapper;
using Domins.Models;
using Handler.Dto;
using Handler.Extensions;
using Handler.MediatorHandler.MediatorCommand.UserUploads;
using Handler.UnityOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.MediatorHandler.MediatorCommandHndler.UserUploads
{
    public class UpdateUserUploadValidatorHandler : IRequestHandler<UpdateUserUploadCommand, UserUpload>
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        public UpdateUserUploadValidatorHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<UserUpload> Handle(UpdateUserUploadCommand request, CancellationToken cancellationToken)
        {
            var find = _unityOfWork.UserUploads.GetByidAsync(request.Id);
            var user = _mapper.Map<UserUpload>(request);
            await ImageHandler.ImageConverterAsync(request.Image);
            return await _unityOfWork.UserUploads.UpdateAsync(user);
        }
    }
}