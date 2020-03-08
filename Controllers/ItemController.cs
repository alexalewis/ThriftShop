using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThriftShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ThriftShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet("location/{locationId}")]
    public async Task<ActionResult<List<Item>>> GetAllItemsByLocation(int locationId)
    {
      var allItems = db.Items.Where(a => a.locationId == locationId);
      if (allItems == null)
      {
        return NotFound();
      }
      else
      {
        return await allItems.ToListAsync();
      }

    }


    [HttpGet("{id}/{locationId}")]
    public async Task<ActionResult<Item>> GetOneItem(int id, int locationId)
    {
      var item = await db.Items.FirstOrDefaultAsync(i => i.Id == id && i.locationId == locationId);
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }


    [HttpPost("{locationId}")]
    public async Task<ActionResult<Item>> AddItemByLocation(int locationId, Item item)
    {
      item.locationId = locationId;
      await db.Items.AddAsync(item);
      await db.SaveChangesAsync();
      return Ok(item);
    }

    [HttpPut("{id}/update")]
    public Item Update(int id)
    {
      var whichItem = db.Items.FirstOrDefault(i => i.Id == id);
      whichItem.NumberInStock -= 1;
      db.SaveChanges();
      return whichItem;
    }

    [HttpPut("{id}/{locationId}")]
    public async Task<ActionResult<Item>> UpdateItem(int id, int locationId, Item newData)
    {
      newData.Id = id;
      newData.locationId = locationId;
      db.Entry(newData).State = EntityState.Modified;
      await db.SaveChangesAsync();
      return Ok(newData);
    }

    [HttpDelete("{id}/{locationId}")]
    public async Task<ActionResult> DeleteItem(int id, int locationId)
    {
      var item = await db.Items.FirstOrDefaultAsync(i => i.Id == id && i.locationId == locationId);
      if (item == null)
      {
        return NotFound();
      }
      db.Items.Remove(item);
      await db.SaveChangesAsync();
      return Ok();
    }

    [HttpGet("sku/{sku}")]
    public async Task<ActionResult<Item>> GetOneItemSKU(string sku)
    {
      var item = await db.Items.Where(i => i.SKU == sku).ToListAsync();
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
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

    [HttpGet("outofstock/{locationId}")]
    public async Task<ActionResult<Item>> GetOutOfStockLocation(int NumberInStock, int locationId)
    {
      var item = await db.Items.Where(i => i.NumberInStock == 0 && i.locationId == locationId).ToListAsync();
      if (item == null)
      {
        return NotFound();
      }
      return Ok(item);
    }

  }
}


