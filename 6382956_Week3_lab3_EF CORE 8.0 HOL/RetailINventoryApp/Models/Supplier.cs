namespace RetailInventoryApp.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public required string SupplierName { get; set; } = string.Empty;
        public required string ContactEmail { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
