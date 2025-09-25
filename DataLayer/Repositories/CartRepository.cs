using DataLayer.Context;
using DataLayer.Models.ViewModels;
using DataLayer.Models;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataLayer.Repositories;


namespace DataLayer.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly MyProjectContext _context;

        public CartRepository(MyProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cartItems = await _context.CartItems
                           .Where(ci => ci.CartId == cartId)
                           .ToListAsync();

            _context.CartItems.RemoveRange(cartItems);
            await UpdateCartTimestampAsync(cartId);
          //  await _context.SaveChangesAsync();
        }

        public async Task<Cart> CreateCartAsync(int userId)
        {
            var cart = new Cart
            {
                UserId = userId,
                CreatedDate = DateTime.Now
            };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> GetCartByUserIdAsync(int userId)
        {
            return await _context.Carts
                 .Include(c => c.CartItem)
                 .Include(c => c.CartItem.Select(ci => ci.VariantCart))
                 .Include(c => c.CartItem.Select(ci => ci.VariantCart.ProductId))
                 .Include(c => c.CartItem.Select(ci => ci.VariantCart.Product))
                 .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemAsync(int cartId, int variantId)
        {
            return await _context.CartItems
                .Where(ci => ci.CartId == cartId && ci.VariantIdCart == variantId).ToListAsync();
        }

        public async Task<decimal> GetCartTotalAsync(int cartId)
        {
            return await _context.CartItems
                      .Where(ci => ci.CartId == cartId)
                      .SumAsync(ci => ci.Quantity * ci.UnitPrice);
        }

        public async Task<int> GetCartTotalItemsCountAsync(int cartId)
        {
            return await _context.CartItems
                        .Where(ci => ci.CartId == cartId)
                        .SumAsync(ci => ci.Quantity);
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await UpdateCartTimestampAsync(item.CartId);
                //await _context.SaveChangesAsync();
            }
        }

        public void UpdateCartAsync(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }


        public async Task AddOrUpdateCartItemAsync(int cartId, int variantId, int quantity, decimal unitPrice, int cartItemId = 0)
        {
            var existingItem = await GetCartItemAsync(cartId, variantId);

            if (cartItemId != 0)
            {
                existingItem.FirstOrDefault(e => e.CartItemId == cartItemId).Quantity = quantity;
                existingItem.FirstOrDefault(e => e.CartItemId == cartItemId).UnitPrice = unitPrice;
                _context.Entry(existingItem).State = EntityState.Modified;
            }
            else
            {
                var newItem = new CartItem
                {
                    CartId = cartId,
                    VariantIdCart = variantId,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                };
                _context.CartItems.Add(newItem);
            }

            await UpdateCartTimestampAsync(cartId);
            //await _context.SaveChangesAsync();
        }

        private async Task UpdateCartTimestampAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart != null)
            {
                cart.UpdatedDate = DateTime.Now;
            }
        }
    }
}
