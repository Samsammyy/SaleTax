namespace SalesTax.Dto
{
    public class ItemsDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
        public bool IsExempt { get; set; }
    }
}
