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
        public IActionResult InitPlayer(  )
        {

            bool isGuest =bool.Parse( HttpContext.Request.Form[SharedReferences.RequestFieldNames.IsGuest]);
            string tokenId = HttpContext.Request.Form[SharedReferences.RequestFieldNames.TokenId];
            string userId = HttpContext.Request.Form[SharedReferences.RequestFieldNames.UserId];
            string email = HttpContext.Request.Form[SharedReferences.RequestFieldNames.Email];
            string authCode = HttpContext.Request.Form[SharedReferences.RequestFieldNames.AuthCode];

           

            PlayerAuthenticationInput input = new PlayerAuthenticationInput(isGuest,tokenId,userId,email,authCode);
            var validation = input.ModelValidator.Validate(input);

            if (!validation.IsValid)
                return BadRequest();

            if (isGuest)
            {
                (int, string, Progress) guestResult = _mediator.InitPlayerAsGuest(input);
                Response.Headers.Add(SharedReferences.ResponseHeaderKeys.JwtToken, guestResult.Item2);
                return StatusCode(guestResult.Item1, guestResult.Item3);
            }

            // not guest
            (int, string, Progress) permanentResult = _mediator.InitPlayerWithService(input);
            Response.Headers.Add(SharedReferences.ResponseHeaderKeys.JwtToken, permanentResult.Item2);
            return StatusCode(permanentResult.Item1, permanentResult.Item3);

        }







    }
}
