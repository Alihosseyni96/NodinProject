using Application.DTO.Product;
using Application.Services.Commands.Product.Add;
using Application.Services.Commands.Product.Delete;
using Application.Services.Queries.Product.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NodinAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Add([FromBody] AddProductCommand req)
        {
            req.UserId = int.Parse(HttpContext.User.Identity!.Name!);
            await _mediator.Send(req);

        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            var req = new DeleteProductCommand()
            {
                ProductId = id,
                LoggedInUserId = int.Parse(HttpContext.User.Identity!.Name!)
            };
            await _mediator.Send(req);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ProductDto>> List([FromQuery]int? createdBy)
        {
            return await _mediator.Send(new GetProductQuery() { CreatedBy = createdBy });
        }



    }
}
