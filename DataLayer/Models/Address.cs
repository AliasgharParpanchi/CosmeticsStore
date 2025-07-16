using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Display(Name ="استان")]
        [Required]
        [MaxLength(150,ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Province { get; set; }

        [Display(Name = "شهر")]
        [Required]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string City { get; set; }

        [Display(Name = "آدرس کامل")]
        [Required]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string FullAddress { get; set; }

        [Display(Name = "پلاک")]
        [Required]
        public int Plaque { get; set; }

        [Display(Name = "واحد")]
        [Required]
        public int Unit { get; set; }

        [Display(Name = "کدپستی")]
        [Required]
        [MaxLength(10, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string PostalCode { get; set; }

        public virtual User Users { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
