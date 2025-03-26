namespace PresentationLayer.Actions_Request.Product
{
    public class UpdateProductAction
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string PhotoName { get; set; }
    }
}
