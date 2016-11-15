using Microsoft.AspNetCore.SignalR.Infrastructure;
using System.Threading;
using nehola.gameoflife.webapp.Hubs;

namespace nehola.gameoflife.webapp.Core
{
    public class GameOfLifeEngine
    {
        private GameOfLifeWorker GameOfLifeWorker { get; set; }

        private Thread WorkerThread { get; set; }
        public GameOfLifeEngine(IConnectionManager signalRConnectionManager)
        {
            GameOfLifeWorker = new GameOfLifeWorker(signalRConnectionManager.GetHubContext<Broadcaster>());

            WorkerThread = new Thread(GameOfLifeWorker.Start);

            WorkerThread.Start();
        }
    }
}