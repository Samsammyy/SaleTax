using SalesTax.Model;

namespace SalesTax.Dto
{
    public class ProductItemDto
    {
        public IEnumerable<string> ItemsReceipt { get; set; }
        public string SalesTax { get; set; }
        public string Total { get; set; }
    }
}
