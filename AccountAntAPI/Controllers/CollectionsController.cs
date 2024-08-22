using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountAntAPI.Data;
using AccountAntAPI.Models;

namespace AccountAntAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CollectionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Collections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollections()
        {
            return await this.FetchItems();
            //var items = await _context.Items.ToListAsync();


            //foreach (var collection in collections)
            //{
            //    foreach (var item in items)
            //    {
            //        if (item.Id == collection.Id)
            //        {
            //            collection.Items.Add(item);
            //        }
            //    }
            //}

            //return collections;
        }

        // GET: api/Collections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        // PUT: api/Collections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollection(int id, Collection collection)
        {
            if (id != collection.Id)
            {
                return BadRequest();
            }

            _context.Entry(collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Collections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Collection>> PostCollection(Collection collection)
        {
            try
            {
                _context.Collections.Add(collection);

                //ICollection<Item> items = [];

                //foreach (Item item in collection.Items)
                //{
                //    _context.Items.Add(item);
                //}

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCollection", new { id = collection.Id }, collection);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Collections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }

            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectionExists(int id)
        {
            return _context.Collections.Any(e => e.Id == id);
        }
    
        private async Task<ActionResult<IEnumerable<Collection>>> FetchItems()
        {
            var collections = await _context.Collections.ToListAsync();
            var items = await _context.Items.ToListAsync();


            foreach (var collection in collections)
            {
                foreach (var item in items)
                {
                    if (item.Id == collection.Id)
                    {
                        collection.Items.Add(item);
                    }
                }
            }

            return collections;

        }
    }
}
