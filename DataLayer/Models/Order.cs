using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int AddressId { get; set; }        
        
        [Required]
        public int OrderStatusId { get; set; }

        [Required]
        [Display(Name ="کد سفارش")]
        public int OrderCode { get; set; }

        [Required]
        [Display(Name = "مبلغ کل")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "تاریخ ثبت سفارش")]
        public DateTime OrderDate { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }        
        [ForeignKey("OrderStatusId")]
        public virtual OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
