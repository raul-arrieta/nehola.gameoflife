using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using nehola.gameoflife.webapp.Core;
using nehola.gameoflife.webapp.Hubs;

namespace nehola.gameoflife.webapp.Controllers
{
    public class HomeController : ApiHubController<Broadcaster>
    {
        public HomeController( IConnectionManager signalRConnectionManager, GameOfLifeEngine gameOfLife)
        : base(signalRConnectionManager)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
