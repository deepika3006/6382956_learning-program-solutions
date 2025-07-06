namespace RetailInventory.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public List<Product>? Products { get; set; }
    }
}
