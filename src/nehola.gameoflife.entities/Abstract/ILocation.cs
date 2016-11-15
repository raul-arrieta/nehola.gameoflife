using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nehola.gameoflife.entities.Abstract
{
    public interface ILocation
    {
        int X { get; }
        int Y { get; }
        bool IsNeightbor(ILocation location);
    }
}
