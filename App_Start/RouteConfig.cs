using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Initiere
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapMvcAttributeRoutes();
            routes.MapRoute("Antrenori", "antrenori/nume",
                new { controller = "Antrenori", action = "Antrenor" });
            routes.MapRoute("Cont", "cont/neinregistrat",
                new { controller = "Cont", action = "Cont" });
            routes.MapRoute("Client", "cont/client",
                    new {controller = "Client",action = "Client" });
            routes.MapRoute("Programari", "cont/programari",
                new { controller = "Programari",action = "Programare"});
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller ="Antrenori", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
