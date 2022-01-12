using Microsoft.AspNetCore.Mvc;

namespace Scheduler.Server.Controllers
{
    [Route("[controller]")]

    public class FlappyBirdMultiplayerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
