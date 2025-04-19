namespace SmartStock.Entities;

public class SaleItem
{
    public int IdSaleItem { get; set; }
    public int IdSale { get; set; }
    public int IdProduct { get; set; }
    public decimal UnitPrice { get; set; }

    public Product Product { get; set; }
    public Sale Sale { get; set; }
}
