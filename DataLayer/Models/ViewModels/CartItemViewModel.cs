using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class CartItemViewModel
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public int VariantId { get; set; }

        public int Quantity { get; set; }

        [Range(0, 100, ErrorMessage = "صحیح نمی باشد")]
        public decimal UnitPrice { get; set; }

        public List<Product_VariantViewModel> VariantViewModels { get; set; }
        public List<ProductViewModel> ProductViewModels { get; set; }
    }
}
