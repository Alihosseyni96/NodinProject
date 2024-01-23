using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands.Product.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _uw;

        public DeleteProductCommandHandler(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product =await _uw.Products.SingleOrDefaultAsync(x=> x.Id == request.ProductId);
            product.ValidePersonGenerated(request.LoggedInUserId);
             _uw.Products.Remove(product);
            await _uw.SaveAsync();

        }
    }
}
