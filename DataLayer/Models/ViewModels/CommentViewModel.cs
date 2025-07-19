using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "متن نظر")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Commnet { get; set; }

        [Required]
        [Display(Name = "تاریخ اضافه شدن محصول")]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD}")]
        public DateTime Created { get; set; }

        [Required]
        [Display(Name = "تایید ادمین")]
        public bool IsApproved { get; set; }

        public UserViewModel User { get; set; }
    }
}
