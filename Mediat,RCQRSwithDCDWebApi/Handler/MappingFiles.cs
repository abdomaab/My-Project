using AutoMapper;
using Domins.Models;
using Handler.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    public class MappingFiles : Profile
    {
        public MappingFiles()
        {
            CreateMap<CartDto, Cart>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CustomProductDto, CustomProduct>()
                .ForMember(src => src.Image, opt => opt.Ignore());
            CreateMap<OrderDto, Order>();
            CreateMap<ProductDto, Product>()
                .ForMember(s1 => s1.Image1, p1 => p1.Ignore())
                .ForMember(s2 => s2.Image2, p2 => p2.Ignore())
                .ForMember(s3 => s3.Image3, p3 => p3.Ignore());
            CreateMap<UserUploadDto, UserUpload>()
                .ForMember(u => u.Image, d => d.Ignore());
            

        }
    }
}
