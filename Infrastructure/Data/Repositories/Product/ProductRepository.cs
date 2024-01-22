using Domain.Entities;
using Domain.IRepositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories.Product
{
    public class ProductRepository : GenericRepository<Domain.Entities.Product> , IProductRepository
    {
        public ProductRepository(NodinContext context) : base(context)
        {
            
        }
    }
}
