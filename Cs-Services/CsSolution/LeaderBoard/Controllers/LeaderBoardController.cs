using Microsoft.AspNetCore.Mvc;

namespace LeaderBoard.Controllers
{
    public class LeaderBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
