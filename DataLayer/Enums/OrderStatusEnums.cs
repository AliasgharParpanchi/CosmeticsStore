using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Enums
{
    public enum OrderStatusEnums
    {
        [Display(Name = "پرداخت شده")]
        Paid = 1,        
        
        [Display(Name = "درحال پردازش")]
        Processing = 2,        
        
        [Display(Name = "ارسال شده")]
        Sent = 3,        
        
        [Display(Name = "دریافت شده")]
        Received = 4,
    }
}
