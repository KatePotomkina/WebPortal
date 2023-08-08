namespace BackPart.Data.DTO;

public class NewProductDto
{
    public string ProductName { get; set; }
    public string ProductCategory { get; set; }
    public decimal  ProductPrice { get; set; }

    public string? ProductSize { get; set; }
}