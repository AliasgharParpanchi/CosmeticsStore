using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Table("ProductVariants")] // تعیین نام جدول صریح
    public class ProductVariant  // حذف underscore
    {
        [Key]
        public int VariantId { get; set; }

        [Required]
        public int ProductId { get; set; }  // نام ساده‌تر

        [Display(Name = "رنگ")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Color { get; set; }

        [Display(Name = "اندازه")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Size { get; set; }

        [Display(Name = "حجم")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Volume { get; set; }

        [Display(Name = "تعداد")]
        [Range(0, int.MaxValue, ErrorMessage = "صحیح نمی باشد")]
        public int Stock { get; set; }

        // Navigation property
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}