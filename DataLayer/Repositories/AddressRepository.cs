using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly MyProjectContext _context;
        private IOrderRepository _orderRepository;
        public AddressRepository(MyProjectContext context) : base(context)
        {
            _context = context;
            _orderRepository = new OrderRepository(context);
        }

        public async Task<Address> GetOrderAddressesAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return await GetByIdAsync(order.AddressId);
        }

        public async Task<IEnumerable<Address>> GetUserAddressesAsync(int userId)
        {
            return await _context.Addresses.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}
