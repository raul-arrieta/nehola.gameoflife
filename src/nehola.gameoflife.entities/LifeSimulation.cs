using System;
using System.Collections.Generic;
using System.Threading;
using nehola.gameoflife.entities.Abstract;

namespace nehola.gameoflife.Entities
{
    public class LifeSimulation : IObservable<IWorld>, ILifeSimulation
    {
        private List<IObserver<IWorld>> Observers { get; set; }

        private IWorld World { get; set; }

        public LifeSimulation(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentOutOfRangeException("Size must be greater than zero");

            Observers = new List<IObserver<IWorld>>();

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

        public IDisposable Subscribe(IObserver<IWorld> observer)
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
            public Unsubscriber(List<IObserver<IWorld>> observers, IObserver<IWorld> observer)
            {
                Observers = observers;
                Observer = observer;
            }

            private List<IObserver<IWorld>> Observers { get; set; }
            private IObserver<IWorld> Observer { get; set; }

            public void Dispose()
            {
                if ((Observers != null) && Observers.Contains(Observer))
                    Observers.Remove(Observer);
            }
        }
    }
}