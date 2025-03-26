using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.ProductDto;
using BusinessLayer.Service;
using DataAccessLayer.Entity;

namespace BusinessLayer.Mapping
{
   public static class ProductExtention
    {
        public static  GetProductDto ToProductDto(this Product p)
        {
            return new GetProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Amount = p.Amount,
                PhotoLocation=p.PhotoLocation
            };
        }

        public static Product ToProduct(this AddProductDto p)
        {
            return new Product
            {

                Name = p.Name,
                Price = p.Price,
                Amount = p.Amount,
                PhotoLocation = p.Picture.FileNameHandler()
            };
        }

        public static Product UpdateDtoToProudct(this UpdateProductDto p)
        {
            return new Product
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Amount = p.Amount
            };
        }

        public static GetListOfPrductDto ProductToGetListOfPrductDto(this Product product)
        {
           
            return new GetListOfPrductDto()
            {

                Name = product.Name,
                Price = product.Price,
                PhotoLocation=product.PhotoLocation
            };
        }


    }
}
