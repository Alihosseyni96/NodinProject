using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.Product
{
    public interface IProductRepository : IGenericRepository<Domain.Entities.Product>
    {
    }
}
