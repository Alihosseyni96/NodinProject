using Application.DTO.Product;
using Application.Services.Commands.Product.Add;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObjectMapping
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            
            CreateMap<AddProductCommand, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
