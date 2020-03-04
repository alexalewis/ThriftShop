using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThriftShop.Models;

namespace ThriftShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet("items")]
    public List<Item> GetAllItems()
    {
      var item = db.Items.OrderBy(i => i.Name);
      return item.ToList();
    }

    [HttpGet("{id}")]
    public Item GetOneItem(int id)
    {
      var oneItem = db.Items.FirstOrDefault(i => i.Id == id);
      return oneItem;
    }

    [HttpPost]
    public Item AddItem(Item item)
    {
      db.Items.Add(item);
      db.SaveChanges();
      return item;
    }

    [HttpPut("{id}/update")]
    public Item Update(int id)
    {
      var whichItem = db.Items.FirstOrDefault(i => i.Id == id);
      whichItem.NumberInStock -= 1;
      db.SaveChanges();
      return whichItem;
    }
    [HttpDelete]
    public ActionResult DeleteOne(int id)
    {
      var delete = db.Items.FirstOrDefault(p => p.Id == id);
      if (delete == null)
      {
        return NotFound();
      }
      db.Items.Remove(delete);
      db.SaveChanges();
      return Ok();
    }

    [HttpGet("SKU/{SKU}")]
    public Item GetBySKU(string SKU)
    {
      var itemBySKU = db.Items.FirstOrDefault(i => i.SKU == SKU);
      return itemBySKU;
    }

    [HttpGet("outofstock")]

    public List<Item> OutOfStock(int NumberInStock)
    {
      var noStock = db.Items.Where(i => i.NumberInStock == 0);
      foreach (var item in noStock)
      {
        Console.WriteLine($"{item.Name}");
      }
      return noStock.ToList();
    }

  }

}
