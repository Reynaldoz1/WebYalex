using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebYalex.Models
{
    public class Autenticado : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Verificar si el usuario está autenticado
            bool estaAutenticado = httpContext.Session["UsuarioAutenticado"] as bool? ?? false;

            return estaAutenticado;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Si el usuario no está autenticado, redirigir al formulario de inicio de sesión
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                { "controller", "Login" },
                { "action", "Login" }
                });
        }
    }
}