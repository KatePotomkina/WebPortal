namespace BackPart.Data.DTO.Response;

public class OrderRersponse
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalCost { get; set; }
    public string Comment { get; set; }
    public string CurrentStatus { get; set; }
    public CustomerResponse Customer { get; set; }
    public List<OrderItemResponse> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
}