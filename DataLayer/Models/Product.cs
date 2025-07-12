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

        [Display(Name = "1نام عکس")]
        public string ImageName1 { get; set; }        
        
        [Display(Name = "2نام عکس")]
        public string ImageName2 { get; set; }        
        
        [Display(Name = "3نام عکس")]
        public string ImageName3 { get; set; }        
        
        [Display(Name = "4نام عکس")]
        public string ImageName4 { get; set; }        
        
        [Display(Name = "5نام عکس")]
        public string ImageName5 { get; set; }

        [Display(Name = "تاریخ اضافه شدن محصول")]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "قیمت")]
        [Range(1,int.MaxValue, ErrorMessage = "صحیح نمی باشد")]
        public int Price { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Range(0,100,ErrorMessage = "صحیح نمی باشد")]
        public Decimal? DiscountPercent { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        public virtual ICollection<Products_Categories> Categories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<Product_Variant> Variant { get; set; }
    }
}
