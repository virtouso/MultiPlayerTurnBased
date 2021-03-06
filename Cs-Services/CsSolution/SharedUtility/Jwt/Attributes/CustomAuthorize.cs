

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SharedUtility.Jwt.Attributes
{

    public class CustomAuthorize : Attribute, IActionFilter
    {



        public string FiltersList;

        IJwtHelper _jwtHelper= new JwtHelper();
        public CustomAuthorize( string filtersList=null)
        {
           
            this.FiltersList = filtersList;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.Keys.Contains(SharedReferences.RequestHeaderKeys.AuthData))
            {
                context.Result = new BadRequestResult();
                return;
            }


            string authData = context.HttpContext.Request.Headers[SharedReferences.RequestHeaderKeys.AuthData];

            var result = _jwtHelper.ValidateJwtToken(authData);

            if (result.Item1==null)
            {
                context.Result = new BadRequestResult();
                return;
            }

            context.HttpContext.Request.Headers.Add(SharedReferences.RequestHeaderKeys.UserId,result.Item1);

        }
    }
}
