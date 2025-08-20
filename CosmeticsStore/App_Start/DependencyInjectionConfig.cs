using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DataLayer.Interfaces;
using DataLayer.Context;
using DataLayer.Repositories;
using DataLayer.Repository;
using System;

namespace CosmeticsStore.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // ثبت کنترلرها
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // ثبت DbContext
            builder.RegisterType<MyProjectContext>().InstancePerRequest();

            // ثبت ریپوزیتوری‌ها
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<InterestRepository>().As<IInterestRepository>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            builder.RegisterType<CartRepository>().As<ICartRepository>();

            // تنظیم رزولور DI
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}