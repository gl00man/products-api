using ProductsAPI.DTOs.Product;

namespace ProductsAPI.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Synchronizes database with new data.
        /// </summary>
        /// <returns></returns>
        public Task<int> SyncDatabase();
        /// <summary>
        /// Gets products data by it's SKU.
        /// </summary>
        /// <param name="sku">Products SKU code</param>
        /// <returns>Instance of the found product object.</returns>
        public Task<ProductDTO> GetProduct(string sku);
    }
}
