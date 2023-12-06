using Auctria.EcommerceStore.Core.Application.Carts;
using Auctria.EcommerceStore.Core.Application.Carts.Commands;
using Auctria.EcommerceStore.Core.Application.Carts.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auctria.EcommerceStore.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILogger<CartController> _logger;
        private readonly IMediator _mediator;

        public CartController(ICartService cartService,
            ILogger<CartController> logger,
            IMediator mediator)
        {
            _cartService = cartService;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("GetCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartVm))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetCart(GetCartQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCart(UpdateCartCommand request)
        {
            var response = await _cartService.UpdateCartService(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateCart(CreateCartCommand request)
        {
            var response = await _cartService.CreateCartService(request);
            return Ok(response);
        }
    }
}
