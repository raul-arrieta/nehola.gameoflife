using Microsoft.AspNetCore.SignalR;
using nehola.gameoflife.Entities;
using System;
using nehola.gameoflife.webapp.Logger;

namespace nehola.gameoflife.webapp.Core
{
    public class GameOfLifeWorker : IObserver<World>
    {
        private IDisposable Unsubscriber { get; set; }

        private LifeSimulation Simulation { get; set; }

        private WebWorldLogger Logger { get; set; }

        public IHubContext HubProxy { get; set; }

        public GameOfLifeWorker(IHubContext hubProxy)
        {
            HubProxy = hubProxy;
        }

        public void Start()
        {
            Simulation = new LifeSimulation(40, 100);
            Logger = new WebWorldLogger();
            Subscribe(Simulation);
            Simulation.Start(3);
        }

        public void Subscribe(IObservable<World> provider)
        {
            if (provider != null)
                Unsubscriber = provider.Subscribe(this);
        }

        public void OnCompleted()
        {
            Unsubscribe();
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(World world)
        {
            world.Print(Logger);

            HubProxy.Clients.All.GenerationUpdated(Logger.OutPut);

            Logger = new WebWorldLogger();
        }

        public virtual void Unsubscribe()
        {
            Unsubscriber.Dispose();
        }
    }
}