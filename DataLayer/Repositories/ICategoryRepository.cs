using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICategoryRepository: IDisposable
    {
        // عملیات درختی
        Task<IEnumerable<Category>> GetCategoryTreeAsync();
        Task<Category> GetCategoryWithChildrenAsync(int id);
        Task<IEnumerable<Category>> GetMainCategoriesAsync();
        Task<IEnumerable<Category>> GetSubcategoriesAsync(int parentId);

        // عملیات CRUD
        Task<Category> GetByIdAsync(int id);
        Task<bool> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);

        // عملیات خاص فروشگاهی
        Task<IEnumerable<Category>> GetFeaturedCategoriesAsync(int count);
        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
        Task<IEnumerable<Category>> GetBreadcrumbAsync(int categoryId);
        Task<bool> HasProductsAsync(int categoryId);

        // سیستم vs کاربر
        Task<IEnumerable<Category>> GetSystemCategoriesAsync();
        Task<IEnumerable<Category>> GetUserCategoriesAsync();
    }
}
