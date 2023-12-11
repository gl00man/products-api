using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductsAPI.DTOs.Product;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepos;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepos)
        {
            _logger = logger;
            _productRepos = productRepos;
        }

        /// <summary>
        /// Synchronizes database.
        /// </summary>
        /// <response code="204">Database successfully synchronized.</response>
        /// <response code="500">An error occurred while proccesing your request.</response>
        [HttpPost("SyncDatbase")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<StatusCodeResult> SyncDatabase()
        {
            var rowsInserted = await _productRepos.SyncDatabase();

            _logger.LogInformation($"Succesfully inserted {rowsInserted} rows into database.");

            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Gets products data by it's sku.
        /// </summary>
        /// <response code="200">Product object.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">An error occurred while proccesing your request.</response>
        [HttpGet("GetProduct")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ProductDTO> GetProduct([FromQuery, BindRequired] string sku)
        {
            return await _productRepos.GetProduct(sku);
        }
    }
}