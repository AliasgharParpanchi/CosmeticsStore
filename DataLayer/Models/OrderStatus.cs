using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        [Required]
        [Display(Name ="وضعیت")]
        public string StatusTitle { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
