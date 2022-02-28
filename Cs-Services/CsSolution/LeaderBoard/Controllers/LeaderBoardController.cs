using LeaderBoard.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBoard.Controllers
{
    public class LeaderBoardController : Controller
    {

        private ILeaderBoardMediator _mediator;
        public LeaderBoardController(ILeaderBoardMediator mediator)
        {
            _mediator = mediator;   
        }


        public IActionResult UpdateLeaderBoardRecord(string leaderBoardName, string jwtToken, int score )
        {
            var resultOk= _mediator.UpdateLeaderBoardRecord(leaderBoardName, jwtToken, score);

            if(resultOk)
                return Ok(resultOk);

            return BadRequest(resultOk);
        }



        public IActionResult GetLeaderBoardScore(string leaderBoardName, string jwtToken) 
        {
            var result= _mediator.GetLeaderBoardScore(leaderBoardName, jwtToken);

            if (result !=null)
                return Ok(result);

            return BadRequest();

        }

        public IActionResult GetLeaderBoard(string leaderBoardName, string jwtToken)
        {
            var result= _mediator.GetLeaderBoard(leaderBoardName, jwtToken);

            if(result?.Any()==true)
                return Ok(result);

            return BadRequest();

        }




    }
}
