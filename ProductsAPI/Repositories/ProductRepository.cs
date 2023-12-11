using ProductsAPI.Models.Product;
using ProductsAPI.Services;
using ProductsAPI.Database;
using ProductsAPI.Clients;
using Dapper;
using System.Data;
using Z.Dapper.Plus;
using ProductsAPI.Models.Exceptions;
using ProductsAPI.DTOs.Product;
using static ProductsAPI.Services.CsvReaderService;
using Z.BulkOperations;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDapperContext _dapperContext;
        private readonly ICsvReaderService _csvReaderService;

        public ProductRepository(ApplicationDapperContext dapperContext, ICsvReaderService csvReaderService)
        {
            _dapperContext = dapperContext;
            _csvReaderService = csvReaderService;
        }

        /// <summary>
        /// Synchronizes database with new data.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SyncDatabase()
        {
            var blobClient = new BlobClient("https://rekturacjazadanie.blob.core.windows.net/zadanie");

            var productsFileBytes = blobClient.GetFileBytes("Products.csv");
            var products = await _csvReaderService.GetRecords<Product>("Products.csv", productsFileBytes, cultureInfo: "en-US");
            var productsToSave = products.Where(x => !x.IsWire && x.Shipping == "24h").ToList();

            var inventoryFileBytes = blobClient.GetFileBytes("Inventory.csv");
            var inventory = await _csvReaderService.GetRecords<Inventory>("Inventory.csv", inventoryFileBytes, delimiter: Delimiter.Comma, cultureInfo: "en-US");
            var inventoryToSave = inventory.Where(x => x.Shipping == "24h").ToList();


            var pricesFileBytes = blobClient.GetFileBytes("Prices.csv");
            var pricesToSave = await _csvReaderService.GetRecords<Price>("Prices.csv", pricesFileBytes, false, Delimiter.Comma);

            var resultInfo = new ResultInfo();

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.UseBulkOptions(options =>
                {
                    options.UseRowsAffected = true;
                    options.ResultInfo = resultInfo;
                });

                connection.BulkInsert(productsToSave);
                connection.BulkInsert(inventory);
                connection.BulkInsert(pricesToSave);
            }

            return resultInfo.RowsAffectedInserted;
        }

        /// <summary>
        /// Gets products data by it's SKU.
        /// </summary>
        /// <param name="sku">Products SKU code</param>
        /// <returns>Instance of the found product object.</returns>
        public async Task<ProductDTO> GetProduct(string sku)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var productQuery = $@"SELECT 
                    name as Name,
                    ean as Ean,
                    producer as ProducerName,
                    category as Category,
                    default_image as DefaultImageUrl,
                    logistic_unit as LogisticUnit,
                    product_id as ProductId
                     FROM [dbo].[Products] WHERE sku = '{sku}'";
                var product = await connection.QuerySingleOrDefaultAsync<Product>(productQuery);

                if (product is null)
                    throw new NotFoundException("Product not found.");

                var inventoryQuery = @$"SELECT 
                quantity as Quantity,
                shipping_cost as ShippingCost
                 FROM [dbo].[Inventory] WHERE product_id = {product.ProductId}";
                var inventory = await connection.QuerySingleOrDefaultAsync<Inventory>(inventoryQuery);

                var priceQuery = $"SELECT net_price FROM [dbo].[Prices] WHERE sku = '{sku}'";
                var price = await connection.QuerySingleOrDefaultAsync<decimal>(priceQuery);

                return new ProductDTO
                {
                    ProductName = product.Name,
                    Ean = product.Ean,
                    Producer = product.ProducerName,
                    Category = product.Category,
                    ProductImageUrl = product.DefaultImageUrl,
                    Quantity = (int)inventory.Quantity,
                    LogisticUnit = product.LogisticUnit,
                    NetPrice = price,
                    ShippingCost = inventory.ShippingCost is null ? 0m : inventory.ShippingCost.Value
                };
            }
        }
    }
}
