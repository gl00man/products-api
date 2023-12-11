using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.DTOs.Product
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string Ean { get; set; }
        public string Producer { get; set; }
        public string Category { get; set; }
        public string ProductImageUrl { get; set; }
        public int Quantity { get; set; }
        public string LogisticUnit { get; set; }
        public decimal NetPrice { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
