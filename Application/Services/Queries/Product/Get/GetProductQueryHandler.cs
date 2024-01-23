using Application.DTO.Product;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Queries.Product.Get
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductDto>>
    {
        private readonly IUnitOfWork _uw;
        private readonly IMapper _mp;

        public GetProductQueryHandler(IUnitOfWork uw, IMapper mp)
        {
            _uw = uw;
            _mp = mp;
        }

        public async Task<List<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var products = await _uw.Products
                .ReadIf(request.CreatedBy is not null, filter: x => x.UserId == request.CreatedBy);
            return _mp.Map<List<ProductDto>>(products);
        }
    }
}
