using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Enums
{

    /// <summary>
    /// دسته‌بندی‌های اصلی سیستم (سطح 1)
    /// </summary>
    public enum MainSystemCategory
    {
        [Display(Name = "برند")]
        Brand = 1,

        [Display(Name = "آرایشی")]
        Makeup = 2,

        [Display(Name = "مراقبت پوست")]
        Skin = 3,

        [Display(Name = "مراقبت و زیبایی مو")]
        Hair = 4,

        [Display(Name = "بهداشت شخصی")]
        Hygiene = 5,

        [Display(Name = "عطر و اسپری")]
        Spray = 6,

        [Display(Name = "لوازم برقی")]
        Electrical = 7,

        [Display(Name = "مکمل غذایی و ورزشی")]
        Supplement = 8,

        [Display(Name = "مد و پوشاک")]
        Fashion = 9,

        [Display(Name = "کالای دیجیکال")]
        Digital = 10,

        [Display(Name = "طلا و نقره")]
        Gold = 11,

    }

    /// <summary>
    /// زیردسته‌های سیستم (سطح 2)
    /// </summary>
    public enum SubSystemCategory
    {
        //زیر مجموعه برند
        [Display(Name = "همه برندها (ا - ی)")]
        AllBrand = 101,        
        [Display(Name = "برندهای برتر")]
        TopBrand = 102,

        //زیر مجموعه آرایشی
        [Display(Name = "آرایش صورت")]
        Face = 201,        
        [Display(Name = "آرایش چشم و ابرو")]
        Eye = 202,        
        [Display(Name = "آرایش لب")]
        Lips = 203,        
        [Display(Name = "آرایش ناخن")]
        Nail = 204,        
        [Display(Name = "ابزار آرایشی")]
        Cosmetic = 205,        
        [Display(Name = "آرایش بدن")]
        Body = 206,

        //زیر مجموعه مراقبت پوست
        [Display(Name = "مراقبت صورت")]
        FacialCare = 301,       
        [Display(Name = "پاک کننده و شوینده")]
        Cleaner = 302,        
        [Display(Name = "مراقبت چشم و ابرو")]
        EyebrowCare = 303,        
        [Display(Name = "مراقبت بدن")]
        BodyCare = 304,
        [Display(Name = "مراقبت لب")]
        LipsCare = 305,        
        [Display(Name = "مراقبت دست و ناخن")]
        HandCare = 306,        
        [Display(Name = "مراقبت پا")]
        FootCare = 307,

        //زیر مجموعه مراقبت زیبایی و مو
        [Display(Name = "شامپو")]
        Shampo = 401,        
        [Display(Name = "مراقبت از مو")]
        HairCare = 402,        
        [Display(Name = "زیبایی مو")]
        HairBeauty = 403,        
        [Display(Name = "ابزار آرایش و پیرایش")]
        MakeupTool = 404,

        //زیر مجموعه بهداشت شخصی
        [Display(Name = "دئورانت و ضد تعریق")]
        Deodorant = 501,
        [Display(Name = "بهداشت دندان و دهان")]
        Dental = 502,
        [Display(Name = "بهداشت بانوان و آقایان")]
        Health = 503,
        [Display(Name = "بدن و حمام")]
        Bath = 504,        
        [Display(Name = "لوازم اصلاح و پیرایش")]
        Shaving = 505,        
        [Display(Name = "محصولات زناشویی و جنسی")]
        Matrimonial = 506,

        //زیر مجموعه عطر و اسپری
        [Display(Name = "عطر و ادکلن")]
        Cologne = 601,
        [Display(Name = "اسپری بدن")]
        BodySpray = 602,
        [Display(Name = "بادی اسپلش")]
        BodySplash = 603,
        [Display(Name = "عطر جیبی")]
        PocketPerfume = 604,
        [Display(Name = "خوشبو کننده هوا")]
        AirFreshener = 605,

        //زیر مجموعه لوازم برقی
        [Display(Name = "ابزار سلامت")]
        HealthTool = 701,
        [Display(Name = "ابزار برقی مو")]
        ElectricHair = 702,
        [Display(Name = "ابزار اصلاح")]
        CorrectionTool = 703,
        [Display(Name = "ابزار مراقبت پوست")]
        SkinCare = 704,

        //زیر مجموعه مکمل غذایی و ورزشی
        [Display(Name = "مکمل بدنسازی")]
        Bodybuilding = 801,
        [Display(Name = "ویتامین و مواد معدنی")]
        Vitamins = 802,
        [Display(Name = "مکمل گیاهی و درمانی")]
        HerbalSupplement = 803,
        [Display(Name = "مواد مغذی")]
        Nutrients = 804,

        //زیر مجموعه مد و پوشاک
        [Display(Name = "اکسسوری")]
        Accessory = 901,
        [Display(Name = "کیف و کوله")]
        Bags = 902,
        [Display(Name = "لباس")]
        Clothes = 903,

        //زیر مجموعه کالای دیجیتال
        [Display(Name = "هدفون، هندزفری و هدست")]
        Headphones = 1001,
        [Display(Name = "ساعت هوشمند")]
        SmartWatch = 1002,
        [Display(Name = "اسپیکر")]
        Speaker = 1003,
        [Display(Name = "لوازم جانبی")]
        Accessories = 1004,

        //زیرمجموعه طلا و نقره
        [Display(Name = "زیورآلات نقره")]
        SilverJewelry = 1101,
    }
}
