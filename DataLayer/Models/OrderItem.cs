using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int VariantIdOrder { get; set; }

        [Required]
        [Display(Name = "تعداد")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name ="مبلغ")]
        public decimal UnitPrice { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }        
        
        [ForeignKey("VariantIdOrder")]
        public virtual ProductVariant VariantOrder { get; set; }
    }
}
