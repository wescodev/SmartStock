namespace SmartStock.Entities;

public class Product
{
    public int IdProduct { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreateDate { get; set; }

    public Category Category { get; set; } // precisa disso pro multi-mapeamento
}
