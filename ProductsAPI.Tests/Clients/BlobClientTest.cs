using FluentAssertions;
using ProductsAPI.Clients;

namespace ProductsAPI.Tests.Clients
{
    public class BlobClientTest
    {
        [Theory]
        [InlineData("https://rekturacjazadanie.blob.core.windows.net/zadanie", "Products.csv")]
        [InlineData("https://rekturacjazadanie.blob.core.windows.net/zadanie", "Inventory.csv")]
        [InlineData("https://rekturacjazadanie.blob.core.windows.net/zadanie", "Prices.csv")]
        public void BlobClient_GetFileBytes_ReturnByteArr(string baseUrl, string fileName)
        {
            //Arrange
            var client = new BlobClient(baseUrl);

            //Act
            var result = client.GetFileBytes(fileName);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<byte[]>();
        }
    }
}
