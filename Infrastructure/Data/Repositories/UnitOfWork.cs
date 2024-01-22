using Domain.IRepositories;
using Domain.IRepositories.Product;
using Domain.IRepositories.User;
using Infrastructure.Data.Repositories.Product;
using Infrastructure.Data.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private NodinContext _context;
        public IProductRepository Products { get; set; }

        public IUserRepository Users { get; set; }

        public UnitOfWork(NodinContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Users = new UserRepository(_context);
        }
    }
}
