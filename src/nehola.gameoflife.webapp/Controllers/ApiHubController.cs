using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR.Infrastructure;

namespace nehola.gameoflife.webapp.Controllers
{
    public abstract class ApiHubController<T> : Controller
        where T : Hub
    {
        private readonly IHubContext _hub;
        public IHubConnectionContext<dynamic> Clients { get; private set; }

        protected ApiHubController(IConnectionManager signalRConnectionManager)
        {
            _hub = signalRConnectionManager.GetHubContext<T>();
            Clients = _hub.Clients;
        }


    }
}
