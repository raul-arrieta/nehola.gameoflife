using System;
using System.Collections.Generic;
using System.Threading;

namespace nehola.gameoflife.Entities
{
    public class LifeSimulation : IObservable<World>
    {
        private List<IObserver<World>> Observers { get; set; }

        private World World { get; set; }

        public LifeSimulation(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException("Size must be greater than zero");

            Observers = new List<IObserver<World>>();

            World = new World(width, height);
            World.Populate();
        }

        public void Start(int? secondsBetweenEvolution = null)
        {
            while (true)
            {
                if (secondsBetweenEvolution.HasValue)
                    Thread.Sleep(secondsBetweenEvolution.Value * 1000);
                World = World.Evolve();
                NotifyNewGeneration();
            }
        }

        public IDisposable Subscribe(IObserver<World> observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
                NotifyNewGeneration();
            }

            return new Unsubscriber(Observers, observer);
        }

        internal void NotifyNewGeneration()
        {
            Observers.ForEach(observer => observer.OnNext(World));
        }

        internal class Unsubscriber : IDisposable
        {
            public Unsubscriber(List<IObserver<World>> observers, IObserver<World> observer)
            {
                Observers = observers;
                Observer = observer;
            }

            private List<IObserver<World>> Observers { get; set; }
            private IObserver<World> Observer { get; set; }

            public void Dispose()
            {
                if ((Observers != null) && Observers.Contains(Observer))
                    Observers.Remove(Observer);
            }
        }
    }
}