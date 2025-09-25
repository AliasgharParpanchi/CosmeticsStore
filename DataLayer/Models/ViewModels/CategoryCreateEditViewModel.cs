using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class CategoryCreateEditViewModel
    {
        public int CategoryId { get; set; }

        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "نام دسته بندی الزامی است")]
        [MaxLength(150, ErrorMessage = "حداکثر 150 کاراکتر مجاز است")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(250, ErrorMessage = "حداکثر 250 کاراکتر مجاز است")]
        public string Description { get; set; }

        [Display(Name = "دسته بندی والد")]
        public int? ParentId { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "نوع سیستم اصلی")]
        public MainSystemCategory? MainSystemType { get; set; }

        [Display(Name = "نوع زیر سیستم")]
        public SubSystemCategory? SubSystemType { get; set; }

        // لیست دسته‌های والد ممکن
        public List<CategorySelectItemViewModel> AvailableParents { get; set; } = new List<CategorySelectItemViewModel>();
    }
}
