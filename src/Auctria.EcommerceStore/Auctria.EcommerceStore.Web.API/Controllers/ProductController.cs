using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auctria.EcommerceStore.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        /// <summary>
        /// Action method to display details of a specific product.
        /// </summary>
        /// /// <param name="GetProductByIdQuery">Query that contains a unique identifier of the product.</param>
        /// <returns>The view containing details of the specified product.</returns>
        [HttpPost]
        [Route("GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductVm))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductById(GetProductByIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Action method to display the list of items in a cart. 
        /// If page number is 0, it is defaulted to 1, if page size is 0, it will be defaulted to 10
        /// </summary>
        /// <returns>The view containing the list of items in a cart.</returns>
        [HttpPost]
        [Route("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductVm>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> ListProducts(ListProductsWithPaginationQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Action method to handle the HTTP POST request for creating a new product.
        /// </summary>
        /// <param name="CreateProductCommand">The data submitted for creating a new product.</param>
        /// <returns>Returns id of the created product if successful; otherwise, returns errors.</returns>
        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        /// <summary>
        /// Action method to handle the HTTP POST request for updating a product.
        /// </summary>
        /// <param name="UpdateProductCommand">The data submitted for updating a product.</param>
        /// <returns>Returns true when update is successful, but an error if update fails</returns>
        [HttpPost]
        [Route("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        /// <summary>
        /// Action method to handle the deletion of a specific product.
        /// </summary>
        /// <param name="DeleteProductCommand">The unique identifier of the product to be deleted.</param>
        [HttpPost]
        [Route("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
