using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands.User.Signin
{
    public class UserSigninCommand : IRequest<int>
    {
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

    }
}
