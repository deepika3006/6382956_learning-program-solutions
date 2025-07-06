namespace RetailInventoryApp.Models;

public class Stock
{
    public int StockId { get; set; }
    public int QuantityAvailable { get; set; }
    public DateTime LastChecked { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
