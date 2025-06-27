using POSWebAPI.Data;
using POSWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace POSWebAPI.Services
{
    public class CartService
    {
        private readonly POSDbContext _context;

        public CartService(POSDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartItem>> GetAllAsync() =>
            await _context.Cart.ToListAsync();

        public async Task AddAsync(CartItem item)
        {
            _context.Cart.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var item = await _context.Cart.FindAsync(id);
            if (item != null)
            {
                _context.Cart.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync()
        {
            _context.Cart.RemoveRange(_context.Cart);
            await _context.SaveChangesAsync();
        }
    }
}
