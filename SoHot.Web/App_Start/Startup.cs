using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using SoHot.Model.Models;
using SoHot.Service;
using SoHot_Data;
using SoHot_Data.Insfrastructure;
using SoHot_Data.Repositories;

[assembly: OwinStartup(typeof(SoHot.Web.App_Start.Startup))]

namespace SoHot.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfiAutofac(app);
            ConfigureAuth(app);
        }

        public void ConfiAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Register your Web API controllers.
            //(register các đối tượng controller khi được khởi tạo
            //mỗi khi gọi IUnitOfWork nó sẽ thay thế bằng UnitOfWork
            //không cần tạo vẫn có mà dủng ??
            //khởi tạo tự động khi có request)

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<SoHotDBContext>().AsSelf().InstancePerRequest();

            ////Asp.net Identity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            //typeof(PostCategoryService -> giống như PostCategoryService
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            //gán vào 1 thùng chứa
            Autofac.IContainer container = builder.Build();
            //thay thế cơ chế mặc định bằng auto
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}
