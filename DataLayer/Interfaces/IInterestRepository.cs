using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IInterestRepository: IRepository<Interest>
    {
        Task<Interest> GetByUserAndProductAsync(int userId, int productId);
        Task<IEnumerable<Interest>> GetUserInterestsAsync(int userId);
        Task<IEnumerable<Interest>> GetProductInterestsAsync(int productId);
        Task<bool> ToggleInterestAsync(int userId, int productId);
        Task<int> GetInterestCountForProductAsync(int productId);
    }
}
