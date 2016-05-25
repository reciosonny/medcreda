using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace MedCreda.WebApi
{
    //public class ServiceActivator : IHttpControllerActivator {
    //    public ServiceActivator(HttpConfiguration configuration) { }

    //    public IHttpController Create(HttpRequestMessage request
    //        , HttpControllerDescriptor controllerDescriptor, Type controllerType) {
    //        var controller = Factory.CreateInstance(controllerType) as IHttpController;
    //        return controller;
    //    }
    //}

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

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
