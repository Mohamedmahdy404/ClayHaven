using BusinessLayer.DTOs.ProductDto;

namespace PresentationLayer.Actions_Request.Order
{
    public class CreateOrderAction
    {
        public string CustomerName { get; set; } = String.Empty;

        public string PaymentToken { get; set; }
        public ICollection<string> SelectedProductsId { get; set; } = new List<string>();

    }
}
