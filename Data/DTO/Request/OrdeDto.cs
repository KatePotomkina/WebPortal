namespace BackPart.Data.DTO;


    public class OrderDto
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public decimal TotalCost { get; set; }
        public string? CurrentStatus { get; set; }
    }
  
