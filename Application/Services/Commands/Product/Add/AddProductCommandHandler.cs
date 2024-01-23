using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands.Product.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IUnitOfWork _uw;
        private readonly IMapper _mp;

        public AddProductCommandHandler(IUnitOfWork uw, IMapper mp)
        {
            _uw = uw;
            _mp = mp;
        }

        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mp.Map<Domain.Entities.Product>(request);
            await _uw.Products.AddAsync(product);
            await _uw.SaveAsync();
        }
    }
}
