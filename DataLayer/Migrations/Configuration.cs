namespace DataLayer.Migrations
{
    using DataLayer.Enums;
    using DataLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.Context.MyProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLayer.Context.MyProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            // ایجاد دسته‌های سطح اول (سیستمی)
            var Brand = new Category
            {
                Name = "برند",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Brand
            };
            var Makeup = new Category
            {
                Name = "آرایشی",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Makeup
            };
            var Skin = new Category
            {
                Name = "مراقبت پوست",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Skin
            };
            var Hair = new Category
            {
                Name = "مراقبت و زیبایی مو",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Hair
            };
            var Hygiene = new Category
            {
                Name = "بهداشت شخصی",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Hygiene
            };
            var Spray = new Category
            {
                Name = "عطر و اسپری",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Spray
            };
            var Electrical = new Category
            {
                Name = "لوازم برقی",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Electrical
            };
            var Supplement = new Category
            {
                Name = "مکمل غذایی و ورزشی",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Supplement
            };
            var Fashion = new Category
            {
                Name = "مد و پوشاک",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Fashion
            };
            var Digital = new Category
            {
                Name = "کالای دیجیکال",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Digital
            };
            var Gold = new Category
            {
                Name = "طلا و نقره",
                Level = 1,
                IsActive = true,
                MainSystemType = MainSystemCategory.Gold
            };

            context.Categories.AddOrUpdate(
              c => c.MainSystemType,
                   Brand,
                   Makeup,
                   Skin,
                   Hair,
                   Hygiene,
                   Spray,
                   Electrical,
                   Supplement,
                   Fashion,
                   Digital,
                   Gold
              );
            context.SaveChanges();


            // ایجاد زیردسته‌ها
            context.Categories.AddOrUpdate(
                c => c.SubSystemType,
                        //برندها
                        new Category
                        {
                            Name = "همه برندها (ا - ی)",
                            ParentId = Brand.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.AllBrand
                        },                        
                        new Category
                        {
                            Name = "برندهای برتر",
                            ParentId = Brand.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.TopBrand
                        },                        
                        //آرایشی
                        new Category
                        {
                            Name = "آرایش صورت",
                            ParentId = Makeup.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Face
                        },                       
                        new Category
                        {
                            Name = "آرایش چشم و ابرو",
                            ParentId = Makeup.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Eye
                        },                        
                        new Category
                        {
                            Name = "آرایش لب",
                            ParentId = Makeup.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Lips
                        },                        
                        new Category
                        {
                            Name = "آرایش ناخن",
                            ParentId = Makeup.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Nail
                        },                        
                        new Category
                        {
                            Name = "ابزار آرایشی",
                            ParentId = Makeup.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Cosmetic
                        },                        
                        new Category
                        {
                            Name = "آرایش بدن",
                            ParentId = Makeup.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Body
                        },
                        //مراقبت پوست
                        new Category
                        {
                            Name = "مراقبت صورت",
                            ParentId = Skin.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.FacialCare
                        },                       
                        new Category
                        {
                            Name = "پاک کننده و شوینده",
                            ParentId = Skin.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Cleaner
                        },                       
                        new Category
                        {
                            Name = "مراقبت چشم و ابرو",
                            ParentId = Skin.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.EyebrowCare
                        },                        
                        new Category
                        {
                            Name = "مراقبت بدن",
                            ParentId = Skin.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.BodyCare
                        },                        
                        new Category
                        {
                            Name = "مراقبت لب",
                            ParentId = Skin.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.LipsCare
                        },                        
                        new Category
                        {
                            Name = "مراقبت دست و ناخن",
                            ParentId = Skin.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.HandCare
                        },                        
                        new Category
                        {
                            Name = "مراقبت پا",
                            ParentId = Skin.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.FootCare
                        },
                        //مراقبت زیبایی و مو
                        new Category
                        {
                            Name = "شامپو",
                            ParentId = Hair.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Shampo
                        },                        
                        new Category
                        {
                            Name = "مراقبت از مو",
                            ParentId = Hair.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.HairCare
                        },                        
                        new Category
                        {
                            Name = "زیبایی مو",
                            ParentId = Hair.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.HairBeauty
                        },                        
                        new Category
                        {
                            Name = "ابزار آرایش و پیرایش",
                            ParentId = Hair.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.MakeupTool
                        },
                        //بهداشت شخصی
                        new Category
                        {
                            Name = "دئورانت و ضد تعریق",
                            ParentId = Hygiene.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Deodorant
                        },                        
                        new Category
                        {
                            Name = "بهداشت دندان و دهان",
                            ParentId = Hygiene.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Dental
                        },                        
                        new Category
                        {
                            Name = "بهداشت بانوان و آقایان",
                            ParentId = Hygiene.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Health
                        },                        
                        new Category
                        {
                            Name = "بدن و حمام",
                            ParentId = Hygiene.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Bath
                        },                        
                        new Category
                        {
                            Name = "لوازم اصلاح و پیرایش",
                            ParentId = Hygiene.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Shaving
                        },                       
                        new Category
                        {
                            Name = "محصولات زناشویی و جنسی",
                            ParentId = Hygiene.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Matrimonial
                        },
                        //عطر و اسپری
                        new Category
                        {
                            Name = "عطر و ادکلن",
                            ParentId = Spray.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Cologne
                        },                        
                        new Category
                        {
                            Name = "اسپری بدن",
                            ParentId = Spray.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.BodySpray
                        },                        
                        new Category
                        {
                            Name = "بادی اسپلش",
                            ParentId = Spray.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.BodySplash
                        },                        
                        new Category
                        {
                            Name = "عطر جیبی",
                            ParentId = Spray.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.PocketPerfume
                        },                        
                        new Category
                        {
                            Name = "خوشبو کننده هوا",
                            ParentId = Spray.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.AirFreshener
                        },                        
                        //لوازم برقی
                        new Category
                        {
                            Name = "ابزار سلامت",
                            ParentId = Electrical.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.HealthTool
                        },                        
                        new Category
                        {
                            Name = "ابزار برقی مو",
                            ParentId = Electrical.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.ElectricHair
                        },                        
                        new Category
                        {
                            Name = "ابزار اصلاح",
                            ParentId = Electrical.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.CorrectionTool
                        },                        
                        new Category
                        {
                            Name = "ابزار مراقبت پوست",
                            ParentId = Electrical.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.SkinCare
                        },                        
                        //مکمل غذایی و ورزشی
                        new Category
                        {
                            Name = "مکمل بدنسازی",
                            ParentId = Supplement.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Bodybuilding
                        },                        
                        new Category
                        {
                            Name = "ویتامین و مواد معدنی",
                            ParentId = Supplement.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Vitamins
                        },                        
                        new Category
                        {
                            Name = "مکمل گیاهی و درمانی",
                            ParentId = Supplement.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.HerbalSupplement
                        },                        
                        new Category
                        {
                            Name = "مواد مغذی",
                            ParentId = Supplement.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Nutrients
                        },
                        //مد و پوشاک
                        new Category
                        {
                            Name = "اکسسوری",
                            ParentId = Fashion.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Accessory
                        },                        
                        new Category
                        {
                            Name = "کیف و کوله",
                            ParentId = Fashion.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Bags
                        },                        
                        new Category
                        {
                            Name = "لباس",
                            ParentId = Fashion.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Clothes
                        },
                        //کالای دیجیتال
                        new Category
                        {
                            Name = "هدفون، هندزفری و هدست",
                            ParentId = Digital.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Headphones
                        },                        
                        new Category
                        {
                            Name = "ساعت هوشمند",
                            ParentId = Digital.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.SmartWatch
                        },                        
                        new Category
                        {
                            Name = "اسپیکر",
                            ParentId = Digital.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Speaker
                        },                        
                        new Category
                        {
                            Name = "لوازم جانبی",
                            ParentId = Digital.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.Accessories
                        },
                        //طلا و نقره
                        new Category
                        {
                            Name = "زیورآلات نقره",
                            ParentId = Gold.CategoryId,
                            Level = 2,
                            IsActive = true,
                            SubSystemType = SubSystemCategory.SilverJewelry
                        }
                );
            context.SaveChanges();
        }
    }
}
