using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Filters;

namespace SharedUtility.Jwt.Attribute
{

    public class CustomAuthorize : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
         if(!context.HttpContext.Request.Headers.Contains())
        }
    }
}
