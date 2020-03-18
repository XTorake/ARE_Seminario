using System.Web.Mvc;
using System.Web.Routing;

namespace CxC_Seminario
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Auditoria",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auditoria", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Carrera",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Carrera", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CarreraxCurso",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CarreraxCurso", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CategoriaProducto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CategoriaProducto", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Correo",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Correo", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Curso",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Curso", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DistritoEclesiastico",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DistritoEclesiastico", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EncabezadoFactura",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EncabezadoFactura", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Iglesia",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Iglesia", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "LineaFactura",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "LineaFactura", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MetodoPago",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MetodoPago", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Pais",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pais", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Persona",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Persona", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Producto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Telefono",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Telefono", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TipoUsuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoUsuario", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Usuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
