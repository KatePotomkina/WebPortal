namespace BackPart.Data.DTO;

public class NewOrderDto
{
  //  public int OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalCost { get; set; }
    public string Comment { get; set; }
    public string CurrentStatus { get; set; }
    public int CustomerId { get; set; }
    public List<NewOrderItemDto> OrderItems { get; set; }

}