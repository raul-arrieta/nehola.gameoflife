using System;
using nehola.gameoflife.Entities;

namespace nehola.gameoflife.entities.Abstract
{
    public interface ILifeSimulation
    {
        void Start(int? secondsBetweenEvolution = null);

        IDisposable Subscribe(IObserver<IWorld> observer);
    }
}
