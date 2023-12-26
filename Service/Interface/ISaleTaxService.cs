using SalesTax.Dto;

namespace SalesTax.Service.Interface
{
    public interface ISaleTaxService
    {
        ResponseDto<ProductItemDto> GenerateReceipt(List<ItemsDto> product);
    }
}
