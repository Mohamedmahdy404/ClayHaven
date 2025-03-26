namespace PresentationLayer.VMs.Product
{
    public class GetProductVM
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string PhotoLocation { get; set; }

    }
}
