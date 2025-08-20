using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class InterestRepository : Repository<Interest>, IInterestRepository
    {
        private readonly MyProjectContext _context;

        public InterestRepository(MyProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Interest> GetByUserAndProductAsync(int userId, int productId)
        {
            return await _context.Interests
                .FirstOrDefaultAsync(i => i.UserId == userId && i.ProductId == productId);
        }

        public async Task<IEnumerable<Interest>> GetUserInterestsAsync(int userId)
        {
            return await _context.Interests
                .Include(i => i.Product)
                .Where(i => i.UserId == userId)
                .OrderByDescending(i => i.InterestId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetProductInterestsAsync(int productId)
        {
            return await _context.Interests
                .Include(i => i.User)
                .Where(i => i.ProductId == productId)
                .ToListAsync();
        }

        public async Task<bool> ToggleInterestAsync(int userId, int productId)
        {
            var existingInterest = await GetByUserAndProductAsync(userId, productId);

            if (existingInterest != null)
            {
                // حذف علاقه‌مندی
                _context.Interests.Remove(existingInterest);
                await _context.SaveChangesAsync();
                return false; // علاقه‌مندی حذف شد
            }

            // افزودن علاقه‌مندی جدید
            var newInterest = new Interest
            {
                UserId = userId,
                ProductId = productId
            };

            _context.Interests.Add(newInterest);
            await _context.SaveChangesAsync();
            return true; // علاقه‌مندی اضافه شد
        }

        public async Task<int> GetInterestCountForProductAsync(int productId)
        {
            return await _context.Interests
                .CountAsync(i => i.ProductId == productId);
        }

        // متدهای اضافی برای مدیریت بهتر
        public async Task AddInterestAsync(int userId, int productId)
        {
            if (await GetByUserAndProductAsync(userId, productId) == null)
            {
                var interest = new Interest
                {
                    UserId = userId,
                    ProductId = productId
                };

                Add(interest);
            }
        }


        public async Task RemoveInterestAsync(int userId, int productId)
        {
            var interest = await GetByUserAndProductAsync(userId, productId);
            if (interest != null)
            {
                 Delete(interest);
            }
        }

        public async Task<bool> IsProductInterestedByUserAsync(int userId, int productId)
        {
            return await _context.Interests
                .AnyAsync(i => i.UserId == userId && i.ProductId == productId);
        }
    }
}
