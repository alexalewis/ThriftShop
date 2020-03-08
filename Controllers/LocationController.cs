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
  public class LocationController : ControllerBase
  {

    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet("locations")]
    public List<Location> GetAllLocations()
    {
      var location = db.Locations.OrderBy(i => i.Address);
      return location.ToList();
    }

    [HttpPost]
    public Location AddLocation(Location location)
    {
      db.Locations.Add(location);
      db.SaveChanges();
      return location;
    }

  }
}