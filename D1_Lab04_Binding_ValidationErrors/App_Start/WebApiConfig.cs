using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using D1_Lab04_Binding_ValidationErrors.Attribute;

namespace D1_Lab04_Binding_ValidationErrors
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //WebApiConfig 進行注冊
            config.Filters.Add(new ModelValidationFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
