using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class CategoryNodeViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "نام دسته بندی")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Name { get; set; }

        [Display(Name = "دسته بندی")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Description { get; set; }


        [Display(Name = "سطح")]
        public int Level { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "سطح نمایشی")]
        public string LevelDisplay { get; set; }

        [Display(Name = "نوع")]
        public string TypeDisplay { get; set; }

        [Display(Name = "دسته والد")]
        public string ParentName { get; set; }

        public bool HasChildren { get; set; }

        public List<CategoryNodeViewModel> Children { get; set; } = new List<CategoryNodeViewModel>();

        // مسیر کامل دسته (breadcrumb)
        public string FullPath { get; set; }

        // تعداد محصولات این دسته
        public int ProductCount { get; set; }

        // تعداد کل زیر مجموعه‌ها
        public int ChildrenCount { get; set; }
    }
}
