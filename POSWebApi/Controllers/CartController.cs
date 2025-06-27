using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSWebAPI.Data;
using POSWebAPI.Models;

namespace POSWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly POSDbContext _context;

        public CartController(POSDbContext context)
        {
            _context = context;
        }

        // GET: api/cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.Cart.ToListAsync();
        }

        // POST: api/cart
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem item)
        {
            _context.Cart.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCartItems), new { id = item.Id }, item);
        }

        // DELETE: api/cart/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var item = await _context.Cart.FindAsync(id);
            if (item == null) return NotFound();

            _context.Cart.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/cart/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(int id, [FromBody] CartItem updatedItem)
        {
            if (id != updatedItem.Id)
            {
                return BadRequest("Item ID mismatch.");
            }

            var item = await _context.Cart.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.ItemName = updatedItem.ItemName;
            item.ItemPrice = updatedItem.ItemPrice;
            item.Quantity = updatedItem.Quantity;

            await _context.SaveChangesAsync();
            return Ok(item);
        }
    }
}
