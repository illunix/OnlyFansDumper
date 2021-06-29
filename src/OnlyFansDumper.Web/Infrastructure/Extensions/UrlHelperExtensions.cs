using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlyFansDumper.Web.Infrastructure.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string MakeTreeViewMenuOpen(this IUrlHelper urlHelper, string subArea)
        {
            var subAreaName = urlHelper.ActionContext.RouteData.Values["subArea"];

            if (subAreaName is null)
            {
                return string.Empty;
            }

            var subAreaNameStr = subAreaName.ToString();

            if (!string.IsNullOrEmpty(subAreaNameStr))
            {
                if (subAreaNameStr.Equals(subArea, StringComparison.OrdinalIgnoreCase))
                {
                    return "menu-open";
                }
            }

            return null;
        }


        public static string MakeClassActive(this IUrlHelper urlHelper, string controller, string action)
        {
            var controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
            var actionName = urlHelper.ActionContext.RouteData.Values["action"].ToString();

            if (!string.IsNullOrEmpty(actionName) && !string.IsNullOrEmpty(controllerName))
            {
                if (controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
                {
                    if (actionName.Equals(action, StringComparison.OrdinalIgnoreCase))
                    {
                        return "active";
                    }
                }
            }

            return null;
        }
    }
}