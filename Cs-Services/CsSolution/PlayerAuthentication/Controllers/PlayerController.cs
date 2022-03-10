using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PlayerAuthentication.Mediator;
using PlayerAuthentication.Models;
using SharedUtility.Jwt;
using System.IdentityModel.Tokens.Jwt;
using static SharedModels.Player;

namespace AuthoritativeGameMechanics.Controllers
{

    public class PlayerController : Controller
    {

        IPlayerAuthenticationMediator _mediator;
        IJwtHelper _jwtHelper;
        public PlayerController(IPlayerAuthenticationMediator mediator, IJwtHelper jwtHelper)
        {
            _mediator = mediator;
            _jwtHelper = jwtHelper;
        }


        [HttpGet("/TestRequest")]
        public IActionResult TestRequest()
        {
            return Ok();
        }



        [HttpPost("/TestJwt")]
        public IActionResult TestJwt(string userName)
        {
            string authToken = _jwtHelper.GenerateJwtToken(ObjectId.Parse(userName));

            string retrievedUserName =   _jwtHelper.ValidateJwtToken(authToken).ToString();

            return Ok(retrievedUserName);
        }


        [HttpPost("/InitPlayer")]
        public IActionResult InitPlayer(bool isGuest, string authToken, string serviceId, string servceEmail, string userName)
        {




            Request.Headers.TryGetValue("Auth", out var authKey);

            PlayerAuthenticationInput input = new PlayerAuthenticationInput(authToken, userName, serviceId, servceEmail, authKey);
            var validation = input.ModelValidator.Validate(input);

            if (!validation.IsValid)
                return BadRequest();

            if (isGuest)
            {
                (int, string, Progress) guestResult = _mediator.InitPlayerAsGuest(input);
                Response.Headers.Add("Auth-Bearer", guestResult.Item2);
                return StatusCode(guestResult.Item1, guestResult.Item3);
            }

            // not guest
            (int, string, Progress) permanentResult = _mediator.InitPlayerWithService(input);
            Response.Headers.Add("Auth-Bearer", permanentResult.Item2);
            return StatusCode(permanentResult.Item1, permanentResult.Item3);

        }



        [HttpPost("/BindService")]
        public IActionResult BindService(string authToken, string userName, string serviceId, string serviceEmail)
        {
            Request.Headers.TryGetValue("Auth", out var authKey);
            PlayerAuthenticationInput input = new PlayerAuthenticationInput(authToken, userName, serviceId, serviceEmail, authKey);
            var (bindResult, progress) = _mediator.BindServiceToPlayer(input);

            return StatusCode(bindResult, progress);

        }




    }
}
