using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Models.Product
{
    public class Inventory
    {
        [Key]
        [Ignore]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_id")]
        [Name("product_id")]
        public int ProductId { get; set; }
        [Column("sku")]
        [Name("sku")]
        public string Sku { get; set; }
        [Column("unit")]
        [Name("unit")]
        public string Unit { get; set; }
        [Column("quantity")]
        [Name("qty")]
        public float Quantity { get; set; }
        [Column("manufacturer")]
        [Name("manufacturer_name")]
        public string Manufacturer { get; set; }
        [Column("shipping")]
        [Name("shipping")]
        public string Shipping { get; set; }
        [Column("shipping_cost")]
        [Name("shipping_cost")]
        public decimal? ShippingCost { get; set; }
    }
}
