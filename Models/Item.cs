using System;

namespace ThriftShop.Models
{
  public class Item
  {
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberInStock { get; set; }
    public double Price { get; set; }
    public DateTime DateOrdered { get; set; } = DateTime.Now;

    public int? locationId { get; set; }
    public Location Location { get; set; }

  }
}