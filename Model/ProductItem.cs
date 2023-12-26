namespace SalesTax.Model
{
    public class ProductItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
        public bool IsExempt { get; set; }
        public double Tax { get; set; }
        public double TotalPrice { get; set; }
        public ProductItem(string name, int quantity, double price, bool isImported, bool isExempt)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            IsImported = isImported;
            IsExempt = isExempt;
        }
    }
}
