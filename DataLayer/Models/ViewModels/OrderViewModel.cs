using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class OrderViewModel
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
        [Display(Name = "کد سفارش")]
        public int OrderCode { get; set; }

        [Required]
        [Display(Name = "مبلغ کل")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "تاریخ ثبت سفارش")]
        public DateTime OrderDate { get; set; }

        public UserViewModel User { get; set; }
        public AddressViewModel Address { get; set; }
        public List<OrderViewModel> OrderViewModels { get; set; }
    }
}
