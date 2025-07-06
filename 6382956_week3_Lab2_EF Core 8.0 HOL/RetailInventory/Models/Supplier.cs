using System.Collections.Generic;

namespace RetailInventory.Models
{
    public class Supplier
{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new List<Product>();
}

}
