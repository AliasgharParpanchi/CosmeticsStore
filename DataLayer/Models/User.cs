using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string LastName { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(50, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل مجاز نمی باشد")]
        public string Email { get; set; }


        [Display(Name = "کد ملی")]
        [MaxLength(10, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string NationalCode { get; set; }

        [Display(Name = "تلفن همراه")]
        [MaxLength(11, ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string Phone { get; set; }

        [Display(Name = "جنسیت")]
        public char Gender { get; set; }

        [Display(Name = "سال تولد")]
        [Range(1300,1500,ErrorMessage ="صحیح نمی باشد")]
        public int? YearBirth { get; set; }
        [Display(Name = "ماه تولد")]
        [Range(1, 12, ErrorMessage = "صحیح نمی باشد")]
        public int? MonthBirth { get; set; }
        [Display(Name = "روز تولد")]
        [Range(1, 31, ErrorMessage = "صحیح نمی باشد")]
        public int? DayBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool IsAdmin { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر باید کمتر از 20 باشد")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر باید بیشتر از 5 باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
