using BusinessLayer.DTOs.ProductDto;

namespace PresentationLayer.VMs.Order
{
    public class GetOrderVM
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; } = String.Empty;
        public Decimal TotalAmount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<GetListOfPrductDto> ListOfProduct { get; set; } = new List<GetListOfPrductDto>();

    }
}
