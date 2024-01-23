using Application.Services.Commands.User.Register;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObjectMapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserRegisterCommand, User>();
        }
    }
}
