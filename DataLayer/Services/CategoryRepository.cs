using DataLayer.Context;
using DataLayer.Models.ViewModels;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataLayer.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyProjectContext db;
        public CategoryRepository(MyProjectContext context)
        {
            this.db = context;
        }

        //public static CategoryNodeViewModel MapToViewModel(Category category)
        //{
        //    return new CategoryNodeViewModel
        //    {
        //        CategoryId = category.CategoryId,
        //        Name = category.Name,
        //        Description = category.Description,
        //        Level = category.Level,
        //        LevelDisplay = category.LevelDisplay,
        //        ParentId = category.ParentId,
        //        ParentName = category.Parent?.Name,
        //        TypeDisplay = GetCategoryTypeDisplay(category),
        //        HasChildren = category.Children?.Any() == true
        //    };
        //}

        //private static string GetCategoryTypeDisplay(Category category)
        //{
        //    if (category.Level == 1) return "اصلی سیستمی";
        //    if (category.Level == 2) return "فرعی سیستمی";
        //    return "کاربری";
        //}

        // عملیات درختی
        public async Task<IEnumerable<Category>> GetCategoryTreeAsync()
        {
            return await db.Categories
            .AsNoTracking()
            .Include(c => c.Children)
            .Where(c => c.ParentId == null)
            .OrderBy(c => c.Name)
            .ToListAsync();
        }

        public async Task<Category> GetCategoryWithChildrenAsync(int id)
        {
            return await db.Categories
            .AsNoTracking()
            .Include(c => c.Children)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<IEnumerable<Category>> GetMainCategoriesAsync()
        {
            return await db.Categories
            .AsNoTracking()
            .Where(c => c.Level == 1)
            .OrderBy(c => c.Name)
            .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetSubcategoriesAsync(int parentId)
        {
            return await db.Categories
            .AsNoTracking()
            .Where(c => c.ParentId == parentId)
            .OrderBy(c => c.Name)
            .ToListAsync();
        }

        // عملیات CRUD
        public async Task<Category> GetByIdAsync(int id)
        {
            return await db.Categories
           .AsNoTracking()
           .FirstOrDefaultAsync(c => c.CategoryId == id);
        }
        public async Task<bool> CreateAsync(Category category)
        {
            try
            {
                Category parent = new Category();
                if (category.Level == 3 && category.ParentId.HasValue)
                {
                    parent = await db.Categories.FindAsync(category.ParentId.Value);
                }
                if (category == null)
                {
                    throw new InvalidOperationException("اطلاعاتی وارد نشده است");
                }
                else if (category.Name == null || category.Name == string.Empty || category.Name == "")
                {
                    throw new InvalidOperationException("نام دسته بندی نمی تواند خالی باشد");
                }
                else if (category.Level != 3)
                {
                    throw new InvalidOperationException("دسته بندی جدید باید از نوع سوم باشد");
                }
                else if (await db.Categories.AnyAsync(x => x.Name == category.Name))
                {
                    throw new InvalidOperationException("نام دسته نباید تکرار باشد");
                }
                else if (parent?.Level != 2)
                {
                    throw new InvalidOperationException("دسته والد نامعتبر است");
                }
                else
                {
                    db.Categories.Add(category);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                throw new InvalidOperationException("خطای غیر منتظره رخ داده است");
            }
        }
        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                var existing = await db.Categories.FindAsync(category.CategoryId);

                if (existing == null)
                {
                    throw new KeyNotFoundException("دسته یافت نشد");
                }
                // جلوگیری از تغییر دسته‌های سیستمی
                else if (existing.MainSystemType != null || existing.SubSystemType != null)
                {
                    throw new InvalidOperationException("امکان ویرایش دسته‌های سیستمی وجود ندارد");
                }

                Category parent = new Category();
                if (category.Level == 3 && category.ParentId.HasValue)
                {
                    parent = await db.Categories.FindAsync(category.ParentId.Value);
                }
                if (category == null)
                {
                    throw new InvalidOperationException("اطلاعاتی وارد نشده است");
                }
                else if (category.Name == null || category.Name == string.Empty || category.Name == "")
                {
                    throw new InvalidOperationException("نام دسته بندی نمی تواند خالی باشد");
                }
                else if (category.Level != 3)
                {
                    throw new InvalidOperationException("دسته بندی جدید باید از نوع سوم باشد");
                }
                else if (await db.Categories.AnyAsync(x => x.Name == category.Name))
                {
                    throw new InvalidOperationException("نام دسته نباید تکرار باشد");
                }
                else if (parent?.Level != 2)
                {
                    throw new InvalidOperationException("دسته والد نامعتبر است");
                }
                existing.Name = category.Name;
                existing.Description = category.Description;
                existing.IsActive = category.IsActive;
                existing.ParentId = category.ParentId;

                await db.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw new InvalidOperationException("خطای غیر منتظره رخ داده است");
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (await db.Products_Categories.AnyAsync(x => x.CategoryId == id))
                {
                    throw new InvalidOperationException("به دلیل استفاده امکان حذف وجود ندارد");
                }

                var category = await db.Categories
                              .Include(c => c.Children)
                              .FirstOrDefaultAsync(c => c.CategoryId == id);
                if (category == null)
                {
                    throw new KeyNotFoundException("دسته یافت نشد");
                }

                if (category.MainSystemType != null || category.SubSystemType != null)
                {
                    throw new InvalidOperationException("امکان حذف دسته‌های سیستمی وجود ندارد");
                }

                if (category.Children.Any())
                {
                    throw new InvalidOperationException("امکان حذف دسته دارای زیردسته وجود ندارد");
                }

                db.Categories.Remove(category);
                await db.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw new InvalidOperationException("خطای غیر منتظره رخ داده است");
            }
        }

        // عملیات خاص فروشگاهی
        public async Task<IEnumerable<Category>> GetFeaturedCategoriesAsync(int count)
        {
            return await db.Categories
            .AsNoTracking()
            .Where(c => c.IsActive && c.MainSystemType == null)
            .OrderByDescending(c => c.Name)
            .Take(count)
            .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            return await db.Categories
            .AsNoTracking()
            .Where(c => c.IsActive && c.Level == 3)
            .Include(c => c.Products.Take(4))
            .OrderBy(c => c.Name)
            .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetBreadcrumbAsync(int categoryId)
        {
            var breadcrumb = new List<Category>();
            var current = await db.Categories
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(c => c.CategoryId == categoryId);

            while (current != null)
            {
                breadcrumb.Insert(0, current);
                current = current.ParentId.HasValue
                    ? await db.Categories.FindAsync(current.ParentId.Value)
                    : null;
            }

            return breadcrumb;
        }
        public async Task<bool> HasProductsAsync(int categoryId)
        {
            return await db.Products_Categories
            .AnyAsync(p => p.CategoryId == categoryId);
        }

        // سیستم vs کاربر
        public async Task<IEnumerable<Category>> GetSystemCategoriesAsync()
        {
            return await db.Categories
                        .AsNoTracking()
                        .Where(c => c.MainSystemType != null || c.SubSystemType != null)
                        .OrderBy(c => c.Name)
                        .ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetUserCategoriesAsync()
        {
            return await db.Categories
                  .AsNoTracking()
                  .Where(c => !(c.MainSystemType != null || c.SubSystemType != null))
                  .OrderBy(c => c.Name)
                  .ToListAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
