using Microsoft.AspNetCore.Mvc;
using PlayerAuthentication.Mediator;
using PlayerAuthentication.Models;
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



        [HttpPost("/InitPlayer")]
        public IActionResult InitPlayer(bool guest, string authToken, string serviceId, string servceEmail, string userName)
        {


            PlayerAuthenticationInput input = new PlayerAuthenticationInput(authToken, userName, serviceId, servceEmail);
            var validation = input.ModelValidator.Validate(input);

            if (!validation.IsValid)
                return BadRequest();

            if (guest)
            {
                (int, string) guestResult = _mediator.InitPlayerAsGuest(input);
                Response.Headers.Add("Auth-Bearer", guestResult.Item2);
                return StatusCode(guestResult.Item1);
            }

            // not guest
            (int, string) permanentResult = _mediator.InitPlayerWithService(input);
            Response.Headers.Add("Auth-Bearer", permanentResult.Item2);
            return StatusCode(permanentResult.Item1);

        }



        [HttpPost("BindService")]
        public IActionResult BindService(string authToken,string userName, string serviceId, string serviceEmail)
        {
            PlayerAuthenticationInput input = new PlayerAuthenticationInput(authToken, userName, serviceId, serviceEmail);
            var (bindResult,progress) = _mediator.BindServiceToPlayer(input);

            return StatusCode(bindResult,progress);

        }




    }
}
