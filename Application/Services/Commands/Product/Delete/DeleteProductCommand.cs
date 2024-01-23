using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands.Product.Delete
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }
        public int LoggedInUserId { get; set; }
        public DeleteProductCommand()
        {
            
        }
    }
}
