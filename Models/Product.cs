using System;
using System.Collections.Generic;

namespace BackPart.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Category { get; set; }

    public decimal  Price { get; set; }

    public string? Size { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
