using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICartRepository: IRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(int userId);
        Task<Cart> CreateCartAsync(int userId);
        Task<IEnumerable<CartItem>> GetCartItemAsync(int cartId, int variantId);
        Task AddOrUpdateCartItemAsync(int cartId, int variantId, int quantity, decimal unitPrice, int cartItemId = 0);
        Task RemoveCartItemAsync(int cartItemId);
        Task ClearCartAsync(int cartId);
        Task<decimal> GetCartTotalAsync(int cartId);
        Task<int> GetCartTotalItemsCountAsync(int cartId);
        void UpdateCartAsync(Cart cart);

    }
}
