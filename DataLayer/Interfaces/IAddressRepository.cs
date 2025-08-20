using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IAddressRepository: IRepository<Address>
    {
        Task<IEnumerable<Address>> GetUserAddressesAsync(int userId);
        Task<Address> GetOrderAddressesAsync(int orderId);
    }
}
