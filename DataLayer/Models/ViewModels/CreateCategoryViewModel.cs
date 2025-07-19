using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.Models.ViewModels
{
    public class CreateCategoryViewModel
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

        [Display(Name = "دسته والد")]
        public int? ParentId { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; } = true;

        // فقط برای نمایش
        public List<SelectListItem> ParentOptions { get; set; } = new List<SelectListItem>();
    }
}
