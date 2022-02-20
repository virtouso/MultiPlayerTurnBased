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




          
   

        [HttpPost("/InitGuestPlayer")]
        public IActionResult InitGuest()
        {
            var id = HttpContext.Request.Form["Id"];
            var userName = HttpContext.Request.Form["UserName"];
            var googlePlayId= HttpContext.Request.Form["GooglePlayId"];
            var password = HttpContext.Request.Form["Password"];
            var deviceId= HttpContext.Request.Form["DeviceId"];
            PlayerAuthenticationInput input = new PlayerAuthenticationInput(id,userName,googlePlayId,password,deviceId);
            var validation = input.ModelValidator.Validate(input);

            if (!validation.IsValid)
                return BadRequest();



            return Ok();

        }




    }
}
