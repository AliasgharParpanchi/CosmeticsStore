using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        //// عملیات پایه
        //Task<Product> GetByIdAsync(int id);
        //Task<IEnumerable<Product>> GetAllAsync();
        //Task<bool> AddAsync(ProductViewModel product);
        //Task<bool> UpdateAsync(ProductViewModel product);
        //Task<bool> DeleteAsync(int id);

        //// مدیریت دسته‌بندی‌ها
        //Task AddCategoryAsync(int productId, int categoryId);
        //Task RemoveCategoryAsync(int productId, int categoryId);
        //Task<IEnumerable<Category>> GetProductCategoriesAsync(int productId);
        //Task<bool> IsInCategoryAsync(int productId, int categoryId);

        //// مدیریت موجودی
        //Task UpdateStockAsync(int productId, int quantity);
        //Task ReserveStockAsync(int productId, int quantity);
        //Task ReleaseStockAsync(int productId, int quantity);
        //Task<int> GetAvailableStockAsync(int productId);

        //// مدیریت تنوع
        //Task AddVariantAsync(Product_Variant variant);
        //Task RemoveVariantAsync(int variantId);
        //Task UpdateVariantAsync(Product_Variant variant);
        //Task<IEnumerable<Product_Variant>> GetProductVariantsAsync(int productId);

        //// عملیات خاص
        //Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, int page = 1, int pageSize = 20);
        //Task<IEnumerable<Product>> SearchProductsAsync(string query, int? categoryId = null);
        //Task<IEnumerable<Product>> GetFeaturedProductsAsync(int count);
        //Task<IEnumerable<Product>> GetRelatedProductsAsync(int productId, int count = 5);

        Task<Product> GetProductWithDetailsAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, int page = 1, int pageSize = 20);
        Task<PagedResult<Product>> GetPagedProductsAsync(ProductViewModel specParams);
        Task UpdateProductStockAsync(int productId, List<Product_VariantViewModel> variants);
        Task UpdateProductCategoriesAsync(int productId, IEnumerable<int> categoryIds);
        Task AddProductVariantAsync(int productId, List<ProductVariant> variant);
        Task<IEnumerable<Product>> GetLastProductRegisterAsync(int take);
    }
}
