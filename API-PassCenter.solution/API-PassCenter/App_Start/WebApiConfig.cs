﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_PassCenter {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Serviços e configuração da API da Web
            var politicas = new EnableCorsAttribute(
            origins: "*",
            methods: "*",
            headers: "*"
            );
        config.EnableCors(politicas);
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;

        }
    }
}
