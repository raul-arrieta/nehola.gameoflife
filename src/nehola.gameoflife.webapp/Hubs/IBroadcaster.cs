using System.Threading.Tasks;

namespace nehola.gameoflife.webapp.Hubs
{
    public interface IBroadcaster
    {
        Task SetConnectionId(string connectionId);
        Task GenerationUpdated(string world);
    }
}
