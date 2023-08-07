using System;
using System.Collections.Generic;

namespace BackPart.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal TotalCost { get; set; }

    public string Comment { get; set; } = null!;

    public string CurrentStatus { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
