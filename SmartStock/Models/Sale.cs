namespace SmartStock.Entities;

public class Sale
{
    public int IdSale { get; set; }
    public int IdClient { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }
    public Client Client { get; set; }
    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
