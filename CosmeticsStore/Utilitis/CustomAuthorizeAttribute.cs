using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticsStore.Utilitis
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public bool Admin { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["UserId"] == null)
                return false;

            if (Admin)
            {
                return (bool)httpContext.Session["IsAdmin"];
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserId"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Index");
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/AccessDenied");
            }
        }
    }
}