using Microsoft.AspNetCore.Mvc;
using PlayerAuthentication.Mediator;
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





        [HttpPost()]
        public string Index()
        {
        return "Result Susscess";
        }


        public string GetDataAndGiveToken()
        {
            throw new NotImplementedException();
            //todo get player data
          //  Player player = new Player();
                     
            //todo validate input data
            // Call the query
            // return the reply to the player with token
        }




    }
}
