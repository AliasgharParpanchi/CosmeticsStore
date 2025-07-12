using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Product_Variant
    {

        [Key]
        public int VariantId { get; set; }

        [Required]
        public int ProductId_Variant { get; set; }

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

        [ForeignKey("ProductId_Variant")]
        public virtual Product Product_Product_Variant { get; set; }
    }
}
