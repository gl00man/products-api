using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Models.Product
{
    public class Price
    {
        [Key]
        [Ignore]
        [Column("id")]
        public int Id { get; set; }
        [Column("warehouse_id")]
        [Index(0)]
        public string WarehouseId { get; set; }
        [Column("sku")]
        [Index(1)]
        public string Sku { get; set; }
        [Column("net_price")]
        [Index(2)]
        public decimal NetPrice { get; set; }
        [Column("net_price_discount")]
        [Index(3)]
        public decimal NetPriceDiscount { get; set; }
        [Column("vat_rate")]
        [Index(4)]
        public int VatRate { get; set; }
        [Column("net_price_logistic_discount")]
        [Index(5)]
        public decimal? NetPriceLogisticDiscount { get; set; }
    }
}
