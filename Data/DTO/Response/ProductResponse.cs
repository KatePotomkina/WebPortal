namespace BackPart.Data.DTO.Response;

public class ProductResponse
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string? ProductCategory { get; set; }

    public decimal? ProductPrice { get; set; }

    public string? ProductSize { get; set; }
}