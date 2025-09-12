using Autofac;
using E_commerce.Application.Contracts;
using E_commerce.Application.Services;
using E_commerce.Context;
using E_commerce.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Presentation
{
    public class AutoFac
    {
        public static IContainer Inject()
        {
            var Builder = new ContainerBuilder();
            //Builder.RegisterType<CategoryService>().As<ICategoryService>();
            //Builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            ////Builder.RegisterType<IGenericRepository<>>().As<GenericRepository<>>();
            //Builder.RegisterType<MyEcommerceContext>().As<MyEcommerceContext>();

            //return Builder.Build();


            Builder.RegisterType<MyContext>().AsSelf();

            // تسجيل الـ Generic Repository
            Builder.RegisterGeneric(typeof(GenericRepository<,>))
                   .As(typeof(IGenericRepository<,>));

            // تسجيل الـ CategoryRepository لو محتاجه
            Builder.RegisterType<UserRepository>().As<IUserRepository>();

            Builder.RegisterType<ProdectService>().As<IProdectService>();

            Builder.RegisterType<UserService>().As<IUserService>();

            Builder.RegisterType<OrderService>().As<IOrderService>();

            Builder.RegisterType<OrderItemService>().As<IOrderItemService>();

            Builder.RegisterType<CartService>().As<ICartService>();

            Builder.RegisterType<CartItemService>().As<ICartItemService>();

            Builder.RegisterType<CategoryService>().As<ICategoryService>();

            return Builder.Build();

        }
    }
}
