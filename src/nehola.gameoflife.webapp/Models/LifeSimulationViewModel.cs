using nehola.gameoflife.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nehola.gameoflife.webapp.Models
{
    public class LifeSimulationViewModel : LifeSimulation
    {
        public LifeSimulationViewModel(int width, int height) : base(width, height)
        {
        }
    }
}
