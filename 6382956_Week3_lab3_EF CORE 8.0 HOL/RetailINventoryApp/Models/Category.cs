namespace RetailInventoryApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
