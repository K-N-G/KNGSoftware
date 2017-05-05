using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KNGSoftware
{
    using System.Collections.Generic;
    using AutoMapper;
    using Models.BindingModels.MyKNG;
    using Models.BindingModels.News;
    using Models.BindingModels.Product;
    using Models.BindingModels.Service;
    using Models.EntityModels;
    using Models.ViewModels.MyKNG;
    using Models.ViewModels.Newses;
    using Models.ViewModels.Products;
    using Models.ViewModels.Services;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<KNGNews, KNGNewsVm>();
                expression.CreateMap<KNGNews, KNGDetailsNewsVm>();
                expression.CreateMap<AddKNGNewsBm, KNGNews>();
                expression.CreateMap<KNGNews, KNGEditNewsVm>();
                expression.CreateMap<KNGEditNewsVm, KNGNews>();
                expression.CreateMap<KNGService, KNGServiceVm>();
                expression.CreateMap<KNGService, KNGDetailsServiceVm>();
                expression.CreateMap<AddKNGServiceBm, KNGService>();
                expression.CreateMap<KNGService, KNGEditServiceVm>();
                expression.CreateMap<KNGEditServiceVm, KNGService>();
                expression.CreateMap<KNGProduct, KNGProductVm>();
                expression.CreateMap<KNGProduct, KNGDetailsProductVm>();
                expression.CreateMap<AddKNGProductBm, KNGProduct>();
                expression.CreateMap<KNGProduct, KNGEditProductVm>();
                expression.CreateMap<KNGEditProductVm, KNGProduct>();
                expression.CreateMap<KNGService, KNGMyServiceVm>();
                expression.CreateMap<KNGProduct, KNGMyProductVm>();
                expression.CreateMap<AddServiceTicketBm, KNGTicket>();
                expression.CreateMap<AddProductTicketBm, KNGTicket>();
                expression.CreateMap<KNGTicket, KNGTicketVm>();
                expression.CreateMap<AddTicketMessageBm, KNGTicketMessage>();

            });
        }
    }
}
