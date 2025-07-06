namespace RetailInventoryApp.Models;

public class Supplier
{
    public int SupplierId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
