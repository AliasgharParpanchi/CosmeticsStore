using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataLayer.Repositories;
using System.Web.UI.WebControls;

namespace DataLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly MyProjectContext _context;
        private ICartRepository _cartRepository;
        private readonly Random _random = new Random();

        public OrderRepository(MyProjectContext context) : base(context)
        {
            _context = context;
            _cartRepository = new CartRepository(_context);
        }


        public void AddOrderItemAsync(OrderItem item)
        {
            _context.OrderItems.Add(item);
        }



        //public Task<Order> CreateOrderAsync(Order order)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Order> CreateOrderFromCartAsync(int userId, int addressId, int paymentMethodId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null || !cart.CartItem.Any())
                return null;

            // ایجاد سفارش جدید
            var order = new Order
            {
                UserId = userId,
                AddressId = addressId,
                OrderStatusId = 1, // وضعیت پیش‌فرض: در انتظار پرداخت
                TotalPrice = cart.CartItem.Sum(i => i.Quantity * i.UnitPrice),
                OrderDate = DateTime.Now,
                OrderCode = await GenerateOrderCodeAsync()
            };

            // افزودن آیتم‌ها
            foreach (var cartItem in cart.CartItem)
            {
                var variant = await GetVariantByIdAsync(cartItem.VariantIdCart);
                if (variant == null) continue;

                order.Items.Add(new OrderItem
                {
                    VariantIdOrder = cartItem.VariantIdCart,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice
                });

                // کاهش موجودی انبار
                variant.Stock -= cartItem.Quantity;
                await UpdateVariantAsync(variant);
            }

            Add(order);
            await _cartRepository.ClearCartAsync(cart.CartId); // پاک کردن سبد خرید

            return order;
        }


        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await GetOrderWithItemsByIdAsync(orderId);
            if (order == null) return false;

            // بازگردانی موجودی انبار
            foreach (var item in order.Items)
            {
                var variant = await GetVariantByIdAsync(item.VariantIdOrder);
                if (variant != null)
                {
                    variant.Stock += item.Quantity;
                    await UpdateVariantAsync(variant);
                }
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                        .Include(o => o.User)
                        .Include(o => o.OrderStatus)
                        .Include(o => o.Items)
                        .OrderByDescending(o => o.OrderDate)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetLastOrderAsync(int take)
        {
            return await _context.Orders
                         .OrderByDescending(o => o.OrderDate)
                         .Take(take)
                         .Include(o => o.User)
                         .Include(o => o.OrderStatus)
                         .Include(o => o.Items)
                         .OrderByDescending(o => o.OrderDate)
                         .ToListAsync();
        }
        public async Task<IEnumerable<OrderStatus>> GetAllOrderStatusesAsync()
        {
            return await _context.OrderStatus.ToListAsync();
        }

        public Task<OrderItem> GetEntityWithSpec(ISpecification<OrderItem> spec)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Address)
                .Include(o => o.OrderStatus)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                        .Include(o => o.OrderStatus)
                        .Include(o => o.Items)
                        .Where(o => o.UserId == userId)
                        .OrderByDescending(o => o.OrderDate)
                        .ToListAsync();
        }

        public async Task<int> GetAllOrdersCountAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<int> GetPaidOrdersCountAsync()
        {
            return await _context.Orders.CountAsync(o => o.OrderStatusId == 1);
        }

        public async Task<int> GetProccessOrdersCountAsync()
        {
            return await _context.Orders.CountAsync(o => o.OrderStatusId == 2);
        }

        public async Task<int> GetSentOrdersCountAsync()
        {
            return await _context.Orders.CountAsync(o => o.OrderStatusId == 3);
        }


        public async Task<Dictionary<string, int>> GetOrderCountPerMonthAsync(DateTime start, DateTime end)
        {
            var result = await _context.Orders
                .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            // تبدیل به دیکشنری با کلید فارسی
            var persianMonths = new Dictionary<int, string>
    {
        {1, "فروردین"}, {2, "اردیبهشت"}, {3, "خرداد"},
        {4, "تیر"}, {5, "مرداد"}, {6, "شهریور"},
        {7, "مهر"}, {8, "آبان"}, {9, "آذر"},
        {10, "دی"}, {11, "بهمن"}, {12, "اسفند"}
    };

            return result.ToDictionary(
                x => $"{persianMonths[x.Month]}",
                x => x.Count
            );
        }

        public async Task<Order> GetOrderWithItemsByIdAsync(int orderId)
        {
            return await _context.Orders
                        .Include(o => o.User)
                        .Include(o => o.Address)
                        .Include(o => o.OrderStatus)
                        .Include(o => o.Items.Select(i => i.VariantOrder))
                        .Include(o => o.Items.Select(i => i.VariantOrder.Product))
                        .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<decimal> GetTotalSalesAsync()
        {
            return await _context.Orders.SumAsync(o => o.TotalPrice);
        }

        public Task<IReadOnlyList<OrderItem>> ListAsync(ISpecification<OrderItem> spec)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateOrderStatusAsync(int orderId, int statusId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.OrderStatusId = statusId;
                //await _context.SaveChangesAsync();
            }
        }

        public async Task<ProductVariant> GetVariantByIdAsync(int variantId)
        {
            return await _context.ProductVariants
                .Include(v => v.Product)
                .FirstOrDefaultAsync(v => v.VariantId == variantId);
        }

        public async Task<ProductVariant> UpdateVariantAsync(ProductVariant variant)
        {
            var existingVariant = await GetVariantByIdAsync(variant.VariantId);
            if (existingVariant == null) return null;

            _context.Entry(existingVariant).CurrentValues.SetValues(variant);
            await _context.SaveChangesAsync();
            return existingVariant;
        }

        public async Task<int> GenerateOrderCodeAsync()
        {
            string code;
            bool isUnique;
            int attempts = 0;
            const int maxAttempts = 10;

            do
            {
                // ترکیب تاریخ و یک کد تصادفی
                var datePart = DateTime.Now.ToString("yyMMdd");
                var randomPart = _random.Next(1000, 9999).ToString();
                code = $"{datePart}-{randomPart}";

                // بررسی منحصر به فرد بودن در دیتابیس
                isUnique = !await _context.Orders.AnyAsync(o => o.OrderCode == Convert.ToInt32(code));

                attempts++;
                if (attempts >= maxAttempts)
                {
                    // استفاده از GUID به عنوان راهکار جایگزین
                    code = "ORD-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
                    isUnique = true; // GUID همیشه منحصر به فرد است
                }
            } while (!isUnique);

            return Convert.ToInt32(code);
        }

    }
}
