using BusinessLayer.DTOs.ProductDto;
using PresentationLayer.Actions_Request;
using PresentationLayer.Actions_Request.Product;
using PresentationLayer.VMs.Product;

namespace PresentationLayer.Mapping
{
    public static class ProductExtention
    {
        public static GetProductVM ToProductVm(this GetProductDto product)
        {
            return new GetProductVM()
            {
                ProductId = product.ProductId,
                Amount = product.Amount,
                Name = product.Name,
                Price = product.Price,
                PhotoLocation=product.PhotoLocation
            };
        }

        public static AddProductDto ToProductDto(this CreateProductAction productAction)
        {

            return new AddProductDto()
            {
                Name = productAction.Name,
                Price = productAction.Price,
                Amount = productAction.Amount,
                Picture = productAction.ProductPic
            };
        }

        public static UpdateProductAction DtoToUpdateProductAction(this GetProductDto productDto)
        {
            return new UpdateProductAction()
            {
                ProductId = productDto.ProductId,
                Price = productDto.Price,
                Amount = productDto.Amount,
                Name = productDto.Name,
                PhotoName=productDto.PhotoLocation

            };

        }
        public static UpdateProductDto UpdateToProductDto(this UpdateProductAction productAction)
        {

            return new UpdateProductDto()
            {
                ProductId = productAction.ProductId,
                Name = productAction.Name,
                Price = productAction.Price,
                Amount = productAction.Amount
            };
        }


    }
}
