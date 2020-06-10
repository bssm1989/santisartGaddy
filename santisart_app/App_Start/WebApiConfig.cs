using santisart_app.Dto;
using santisart_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData;
namespace santisart_app
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
  
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<OrdersDto>("DD_Orders1");
            builder.EntitySet<CustomerDto>("CustomerDto");
            builder.EntitySet<OrderDetailDto>("OrderDetailDto");
            builder.EntitySet<OrderDetailDto>("DD_Order_detail1");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
