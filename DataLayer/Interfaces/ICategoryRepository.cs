using DataLayer.Models;
using DataLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<List<Category>> GetCategoryTreeAsync();
        Task<Category> GetCategoryWithChildrenAsync(int id);
        Task<IEnumerable<Category>> GetMainCategoriesAsync();
        Task<IEnumerable<Category>> GetSubcategoriesAsync(int parentId);
        Task<IEnumerable<Category>> GetSystemCategoriesAsync();
        Task<IEnumerable<Category>> GetUserCategoriesAsync();
       
    }
}
