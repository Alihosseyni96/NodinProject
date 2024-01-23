using Application.Services.Commands.User.Register;
using Application.Services.Commands.User.Signin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodinAPI.Common.Extensions;

namespace NodinAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task UserRegister([FromBody] UserRegisterCommand req)
        {
                var userId = await _mediator.Send(req);
                await HttpContext.SetAuthenticationTokenAsync(userId);
        }

        [HttpPost]
        public async Task UserSignin([FromBody]UserSigninCommand req)
        {
            var userId = await _mediator.Send(req);
            await HttpContext.SetAuthenticationTokenAsync(userId);
        }


    }
}
