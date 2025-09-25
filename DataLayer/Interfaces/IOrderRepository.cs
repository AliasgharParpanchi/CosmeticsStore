using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> GetOrderWithItemsByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        //Task<Order> CreateOrderAsync(Order order);
        Task UpdateOrderStatusAsync(int orderId, int statusId);
        Task<Order> CreateOrderFromCartAsync(int userId, int addressId, int paymentMethodId);
        void AddOrderItemAsync(OrderItem item);
        Task<IEnumerable<OrderStatus>> GetAllOrderStatusesAsync();
        Task<int> GetOrdersCountAsync();
        Task<decimal> GetTotalSalesAsync();
        Task<bool> DeleteOrderAsync(int orderId);
        Task<int> GenerateOrderCodeAsync();
        Task<ProductVariant> GetVariantByIdAsync(int variantId);
        Task<ProductVariant> UpdateVariantAsync(ProductVariant variant);
    }
}
