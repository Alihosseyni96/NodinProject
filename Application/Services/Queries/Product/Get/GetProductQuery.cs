using Application.DTO.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Queries.Product.Get
{
    public class GetProductQuery : IRequest<List<ProductDto>>
    {
        public int? CreatedBy { get; set; }
    }
}
