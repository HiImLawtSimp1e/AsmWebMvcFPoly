using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASM_hungnqph19112_CS4.Models.Authorization
{
    public class Authorization:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("UserName") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"Controller","Auth" },
                        {"Action","Login" }
                    });
            }
            else
            {
              if (context.HttpContext.Session.GetString("Role") != "1")
                    context.Result = new RedirectToRouteResult(
              new RouteValueDictionary
              {
                        {"Controller","Auth" },
                        {"Action","Forbidden" }
              });
              
            }
        }
    }
}
