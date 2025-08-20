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
using System.Data.Entity.Migrations;
using DataLayer.Repositories;
using DataLayer.Specification;
using System.Linq.Dynamic.Core;

namespace DataLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly MyProjectContext _context;

        public ProductRepository(MyProjectContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Product> GetProductWithDetailsAsync(int id)
        {
            return await _context.Products
            .Include(p => p.Categories.Select(pc => pc.Categories))
            .Include(p => p.Variant)
            .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, int page = 1, int pageSize = 20)
        {
            List<int> productId = await _context.Products_Categories
                                                        .Where(pc=> pc.CategoryId == categoryId)
                                                        .Select(pc=> pc.ProductId ).ToListAsync();

            return await _context.Products.Where(p=> p.Equals(productId))
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }



        public async Task UpdateProductCategoriesAsync(int productId, IEnumerable<int> categoryIds)
        {
            var product = await _context.Products
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null) return;

            // حذف دسته‌بندی‌های قدیمی
            var categoriesToRemove = product.Categories
                .Where(pc => !categoryIds.Contains(pc.CategoryId))
                .ToList();

            foreach (var category in categoriesToRemove)
            {
                product.Categories.Remove(category);
            }

            // افزودن دسته‌بندی‌های جدید
            var existingCategoryIds = product.Categories.Select(pc => pc.CategoryId);
            var categoriesToAdd = categoryIds.Except(existingCategoryIds);

            foreach (var categoryId in categoriesToAdd)
            {
                product.Categories.Add(new Products_Categories
                {
                    ProductId = productId,
                    CategoryId = categoryId
                });
            }

            _context.Products.AddOrUpdate(product);
        }

        public async Task UpdateProductStockAsync(int productId, List<Product_VariantViewModel> variants)
        {
            // Fetch all existing variants for the product in one query
            var existingVariants = await _context.Product_Variants
                .Where(v => v.ProductId_Variant == productId)
                .ToListAsync();

            foreach (var variant in variants)
            {
                // Find matching variant by attributes
                var inventory = existingVariants.FirstOrDefault(v =>
                    v.Color == variant.Color &&
                    v.Size == variant.Size &&
                    v.Volume == variant.Volume);

                if (inventory == null)
                {
                    // Create new variant
                    _context.Product_Variants.Add(new Product_Variant
                    {
                        ProductId_Variant = productId,
                        Stock = variant.Stock,
                        Color = variant.Color,
                        Size = variant.Size,
                        Volume = variant.Volume
                    });
                }
                else
                {
                    // Update existing variant
                    inventory.Stock = variant.Stock;
                }
                _context.Product_Variants.AddOrUpdate(inventory);
            }

            
        }

        public async Task<PagedResult<Product>> GetPagedProductsAsync(ProductViewModel specParams)
        {
            var spec = new ProductSpecification(specParams);
            var countSpec = new ProductSpecification(specParams);

            var totalItems = await CountAsync(countSpec);
            var products = await ListAsync(spec);


            return new PagedResult<Product>() {
                CurrentPage = specParams.PageIndex,
                PageSize = specParams.PageSize,
                RowCount = totalItems,
                Queryable = (IQueryable<Product>)products
            };
        }


        public Task AddProductVariantAsync(int productId, List<Product_Variant> variant)
        {
            throw new NotImplementedException();
        }
    }
}
