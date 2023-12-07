using Auctria.EcommerceStore.Core.Application.Carts;
using Auctria.EcommerceStore.Core.Application.Carts.Commands;
using Auctria.EcommerceStore.Core.Application.Carts.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auctria.EcommerceStore.Web.API.Controllers
{
    /// <summary>
    /// Controller responsible for managing Cart.
    /// </summary>
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

        /// <summary>
        /// Action method to display details of a specific cart.
        /// </summary>
        /// /// <param name="GetCartByIdQuery">Query that contains a unique identifier of the cart.</param>
        /// <returns>The view containing details of the specified cart.</returns>
        [HttpPost]
        [Route("GetCartById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartVm))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetCartById(GetCartByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        /// <summary>
        /// Action method to handle the HTTP POST request for updating a cart.
        /// </summary>
        /// <param name="UpdateCartCommand">The data submitted for updating a cart.</param>
        /// <returns>Returns true when update is successful, but an error if update fails</returns>
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

        /// <summary>
        /// Action method to handle the HTTP POST request for creating a new cart.
        /// </summary>
        /// <param name="CreateCartCommand">The data submitted for creating a new cart.</param>
        /// <returns>Returns the id of the created cart if successful; otherwise, returns an error.</returns>
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
