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
using NPOI.SS.Formula.Functions;


namespace DataLayer.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly MyProjectContext _context;

        public CategoryRepository(MyProjectContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Category> GetCategoryWithChildrenAsync(int id)
        {
            return await _context.Categories
            .Include(c => c.Children)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<IEnumerable<Category>> GetMainCategoriesAsync()
        {
            return await _context.Categories
            .Where(c => c.Level == 1)
            .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetSubcategoriesAsync(int parentId)
        {
            return await _context.Categories
            .Where(c => c.Level == 2)
            .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetSystemCategoriesAsync()
        {
            return await _context.Categories
            .Where(c => c.Level == 3)
            .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetUserCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        // متدهای کمکی برای ایجاد درخت دسته‌بندی
        public async Task<List<Category>> GetCategoryTreeAsync()
        {
            var allCategories = await GetUserCategoriesAsync();
            return BuildCategoryTree(allCategories.ToList(), null);
        }

        private List<Category> BuildCategoryTree(List<Category> allCategories, int? parentId)
        {
            return allCategories
                .Where(c => c.ParentId == parentId)
                .OrderBy(c => c.Name)
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description,
                    Level = c.Level,
                    ParentId = c.ParentId,
                    IsActive = c.IsActive,
                    MainSystemType = c.MainSystemType,
                    SubSystemType = c.SubSystemType,
                    Children = BuildCategoryTree(allCategories, c.CategoryId)
                })
                .ToList();
        }
    }
}
