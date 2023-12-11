using CsvHelper.Configuration.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductsAPI.Models.Product
{
    public class Product
    {
        [Key]
        [Ignore]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_id")]
        [Name("ID")]
        public int ProductId { get; set; }
        [Column("sku")]
        [Name("SKU")]
        public string? Sku { get; set; }
        [Column("name")]
        [Name("name")]
        public string? Name { get; set; }
        [Column("ean")]
        [Name("EAN")]
        public string? Ean { get; set; }
        [Column("producer")]
        [Name("producer_name")]
        public string? ProducerName { get; set; }
        [Column("category")]
        [Name("category")]
        public string? Category { get; set; }
        [Column("shipping")]
        [Name("shipping")]
        public string? Shipping { get; set; }
        [Column("logistic_unit")]
        [Name("package_size")]
        public string? LogisticUnit { get; set; }
        [Column("is_wire")]
        [Name("is_wire")]
        [Default(false)]
        public bool IsWire { get; set; }
        [Column("available")]
        [Name("available")]
        [Default(false)]
        public bool IsAvailable { get; set; }
        [Column("is_vendor")]
        [Name("is_vendor")]
        [Default(false)]
        public bool IsVendor { get; set; }
        [Column("default_image")]
        [Name("default_image")]
        public string? DefaultImageUrl { get; set; }
    }
}
