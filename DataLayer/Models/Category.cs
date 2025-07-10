using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        [Display(Name ="نام دسته بندی")]
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


        // افزودن فیلدهای Enum
        public MainSystemCategory? MainSystemType { get; set; }

        public SubSystemCategory? SubSystemType { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Products_Categories> Products { get; set; }


    }
}
