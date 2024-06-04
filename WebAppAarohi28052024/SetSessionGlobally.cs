using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAarohi28052024
{
    public class SetSessionGlobally : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var res = context.HttpContext.Session.GetString("UserName"); // null
            if (res == null)
            {
                context.Result =
    new RedirectToRouteResult(
        new RouteValueDictionary {
                            { "controller", "Spcurd" },
                            { "action","Login" }
        });

            }
        }
    }
}
