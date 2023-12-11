using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using ProductsAPI.Controllers;
using ProductsAPI.DTOs.Product;
using ProductsAPI.Repositories;

namespace ProductsAPI.Tests.Controllers
{
    public class ProductControllerTest
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepos;

        public ProductControllerTest()
        {
            _logger = A.Fake<ILogger<ProductController>>();
            _productRepos = A.Fake<IProductRepository>();
        }

        [Theory]
        [InlineData("0001-00017-64576")]
        [InlineData("0001-00017-20835")]
        [InlineData("0001-00017-20843")]
        [InlineData("0001-00017-20839")]
        public void ProductController_GetProduct_ReturnProductDTO(string sku)
        {
            //Arrange
            var controller = new ProductController(_logger, _productRepos);

            //Act
            var result = controller.GetProduct(sku);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ProductDTO>));
        }
    }
}
