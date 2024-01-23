using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands.Product.Add
{
    public class AddProductCommand : IRequest
    {
        public string Name { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public DateTime ProduceDate { get; set; }
        public int UserId { get; set; }


        public AddProductCommand()
        {
            
        }
    }
}
