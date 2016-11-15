using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nehola.gameoflife.Entities.Logger;

namespace nehola.gameoflife.entities.Abstract
{
    public interface IWorld
    {
        void Populate();
        IWorld Evolve();
        void Print(IWorldLogger logger);
    }
}
