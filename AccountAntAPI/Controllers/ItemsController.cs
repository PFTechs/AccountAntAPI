using AccountAntAPI.Data;
using AccountAntAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountAntAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly DatabaseContext _db;
        public ItemsController
        (DatabaseContext db)
        {
            _db = db;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Item> results = this._db.Items.ToList();

            return results.Count == 0 ? NotFound() : Ok(results);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Item result = this._db.Items.Find(id);
            return result == null ? NotFound() : Ok(result);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public IActionResult Post([FromBody] Item[] items)
        {
            List<Item> itemsAdded = new ();
            foreach (Item item in items)
            {
               this._db.Items.Add(item);
               itemsAdded.Add(item);
            }
            this._db.SaveChanges();

            return itemsAdded == null ? NotFound() : Ok(itemsAdded);
        }


        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item item)
        {

            this._db.Items.Update(item);
            this._db.SaveChanges();
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._db.Items.Where(x => x.Id == id).ExecuteDelete();

            return Ok();
        }
    }
}
