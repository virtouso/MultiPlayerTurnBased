using Microsoft.AspNetCore.Mvc;
using PlayerAuthentication.Mediator;
using PlayerAuthentication.Models;
using SharedModels;
namespace AuthoritativeGameMechanics.Controllers
{

    public class PlayerController : Controller
    {

        IPlayerAuthenticationMediator _mediator;
        public PlayerController(IPlayerAuthenticationMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("/TestRequest")]
        public IActionResult TestRequest()
        {
            return Ok();
        }



        [HttpPost("/InitGuestPlayer")]
        public IActionResult InitGuest()
        {
            string id = HttpContext.Request.Form["Id"];
            string userName = HttpContext.Request.Form["UserName"];
            string googlePlayId= HttpContext.Request.Form["GooglePlayId"];
            string password = HttpContext.Request.Form["Password"];
            string deviceId= HttpContext.Request.Form["DeviceId"];
            PlayerAuthenticationInput input = new PlayerAuthenticationInput(id,userName,googlePlayId,password,deviceId);
            var validation = input.ModelValidator.Validate(input);

            if (!validation.IsValid)
                return BadRequest();

            var result= _mediator.InitGuestPlayer(input);

            Response.Headers.Add("Auth-Bearer",result.Data);
            return Ok();

        }






    }
}
