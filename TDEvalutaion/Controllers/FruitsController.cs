using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDEvalutaion.Models.EntityFramework;

namespace TDEvalutaion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly TDEvaluationDBContext _context;

        public FruitsController(TDEvaluationDBContext context)
        {
            _context = context;
        }

        // GET: api/Fruits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fruit>>> GetFruits()
        {
          if (_context.Fruits == null)
          {
              return NotFound();
          }
            return await _context.Fruits.ToListAsync();
        }

        // GET: api/Fruits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fruit>> GetFruit(int id)
        {
          if (_context.Fruits == null)
          {
              return NotFound();
          }
            var fruit = await _context.Fruits.FindAsync(id);

            if (fruit == null)
            {
                return NotFound();
            }

            return fruit;
        }

        // PUT: api/Fruits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFruit(int id, Fruit fruit)
        {
            if (id != fruit.IdFruit)
            {
                return BadRequest();
            }

            _context.Entry(fruit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitExists(id))
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

        // POST: api/Fruits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fruit>> PostFruit(Fruit fruit)
        {
          if (_context.Fruits == null)
          {
              return Problem("Entity set 'TDEvaluationDBContext.Fruits'  is null.");
          }
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFruit", new { id = fruit.IdFruit }, fruit);
        }

        // DELETE: api/Fruits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruit(int id)
        {
            if (_context.Fruits == null)
            {
                return NotFound();
            }
            var fruit = await _context.Fruits.FindAsync(id);
            if (fruit == null)
            {
                return NotFound();
            }

            _context.Fruits.Remove(fruit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FruitExists(int id)
        {
            return (_context.Fruits?.Any(e => e.IdFruit == id)).GetValueOrDefault();
        }
    }
}
