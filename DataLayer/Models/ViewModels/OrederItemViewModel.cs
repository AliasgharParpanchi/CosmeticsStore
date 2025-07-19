using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class OrederItemViewModel
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int VariantId { get; set; }

        [Required]
        [Display(Name = "تعداد")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "مبلغ")]
        public decimal UnitPrice { get; set; }

        public List<ProductViewModel> ProductViewModels { get; set; }
        public List<Product_VariantViewModel> VariantViewModels { get; set; }
    }
}
