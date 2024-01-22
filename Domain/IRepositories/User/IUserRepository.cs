using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.User
{
    public interface IUserRepository : IGenericRepository<Domain.Entities.User>
    {
    }
}
