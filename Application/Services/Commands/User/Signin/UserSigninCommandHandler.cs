using Application.Common.Extentions;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands.User.Signin
{
    public class UserSigninCommandHandler : IRequestHandler<UserSigninCommand, int>
    {
        private readonly IUnitOfWork _uw;

        public UserSigninCommandHandler(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<int> Handle(UserSigninCommand request, CancellationToken cancellationToken)
        {
            
            var user = await _uw.Users
                .SingleOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber && x.Password == request.Password.Hash());
            if (user is null)
                throw new Exception("کاربری با این مشخصات یافت نشد");

            return user.Id;
        }
    }
}
