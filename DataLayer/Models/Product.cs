using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "نام محصول")]
        [MaxLength(300 ,ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string ProductName { get; set; }

        [Display(Name = "کد محصول")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        [RegularExpression("@[a-z|A-Z| |1-9]*", ErrorMessage = "کاراکتر مجاز نمی باشد")]
        public string ProductCode { get; set; }

        [Display(Name = "معرفی محصول")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "نحوه مصرف")]
        [AllowHtml]
        public string HowToUse { get; set; }

        [Display(Name = "نام عکس")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ اضافه شدن محصول")]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        public virtual ICollection<Products_Categories> Categories { get; set; }
    }
}
