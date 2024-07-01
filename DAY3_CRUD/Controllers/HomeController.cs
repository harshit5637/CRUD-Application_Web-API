using DAY3_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAY3_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private static List<Item> items = new List<Item>
  {  
  
      new Item
      {
        Id = 1,
        Name = "Apple",
        Description = "Fresh"
      },
      new Item
      {
          Id = 2,
          Name = "Mango",
          Description = "Description"
      }
  };

        // GET: api/Items
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(items);
        }



        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/Items
        [HttpPost]
        public ActionResult<Item> PostItem(Item item)
        {
            item.Id = items.Max(i => i.Id) + 1;
            items.Add(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult PutItem(int id, Item item)
        {
            var existingItem = items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;

            return NoContent();
        }


        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public string DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return " not found";
            }

            items.Remove(item); 

            return "removed";
        }
    }
}
