﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using D1_Lab06_FromUri_FromBody.Attribute;

namespace D1_Lab06_FromUri_FromBody
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ModelValidationFilterAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
