using Application.Common.Extentions;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Commands.User.Register
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, int>
    {
        private readonly IUnitOfWork _uw;
        private readonly IMapper _mp;

        public UserRegisterCommandHandler(IUnitOfWork uw, IMapper mp)
        {
            _uw = uw;
            _mp = mp;
        }

        public async Task<int> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var user  = _mp.Map<Domain.Entities.User>(request);
            user.Password = user.Password.Hash();
            await _uw.Users.AddAsync(user);
            await _uw.SaveAsync();
            return user.Id;

        }
    }
}
