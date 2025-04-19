namespace SmartStock.Entities;

public class Client
{
    public int IdClient { get; set; }
    public string Name { get; set; } = string.Empty;
    public string EmailClient { get; set; } = string.Empty;
    public string CpfClient { get; set; }
    public string? PhoneClient { get; set; }
    public DateTime? CreateDate { get; set; }
}
