using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class CategoryTreeViewModel
    {
        public List<CategoryNodeViewModel> RootCategories { get; set; } = new List<CategoryNodeViewModel>();

        // آمار کلی
        public int TotalCategories { get; set; }
        public int ActiveCategories { get; set; }
        public int InactiveCategories { get; set; }
    }
}
