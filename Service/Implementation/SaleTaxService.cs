using SalesTax.Dto;
using SalesTax.Model;
using SalesTax.Service.Interface;

namespace SalesTax.Service.Implementation
{
    public class SaleTaxService : ISaleTaxService
    {
        public ResponseDto<ProductItemDto> GenerateReceipt(List<ItemsDto> product)
        {
            var response = new ResponseDto<ProductItemDto>();
            try
            {

                if (product == null || product.Count == 0)
                {
                    response.ErrorMessages = new List<string>() { "Product Items list is empty." };
                    response.StatusCode = 400;
                    response.DisplayMessage = "Error";
                    return response;
                }
                var items = new List<ProductItem>();
                foreach (var item in product)
                {
                    var newItem = new ProductItem(item.Name, item.Quantity, item.Price, item.IsImported, item.IsExempt);
                    items.Add(newItem);
                }
                double salesTaxes = 0;
                double total = 0;

                foreach (var item in items)
                {
                    double tax = CalculateTax(item.Price, item.IsImported, item.IsExempt);
                    item.Tax = tax;
                    item.TotalPrice = item.Price + tax;
                    salesTaxes += tax;
                    total += item.TotalPrice;
                }

                var receipts = new List<string>();
                foreach (var item in items)
                {
                    if (item.Quantity > 1)
                    {
                        receipts.Add($"{item.Name}: {item.TotalPrice} ({item.Quantity} @ {item.TotalPrice / item.Quantity:F2})");
                    }
                    else
                    {
                        receipts.Add($"{item.Name}: {item.TotalPrice:F2}");
                    }
                }
                var result = new ProductItemDto();
                result.ItemsReceipt = receipts;
                result.SalesTax = $"{salesTaxes:F2}";
                result.Total = $"{total:F2}";
                response.Result = result;
                response.StatusCode = 200;
                response.DisplayMessage = "Successful";
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessages = new List<string> { ex.Message };
                response.DisplayMessage = "Error";
                response.StatusCode = 500;
                return response;

            }
        }
        private double CalculateTax(double price, bool isImported, bool isExempt)
        {
            double taxRate = isImported ? 0.05 : 0.1;
            if (isExempt)
            {
                return 0;
            }
            else
            {
                double tax = price * taxRate;
                return Math.Ceiling(tax / 0.05) * 0.05;
            }
        }
    }
}
