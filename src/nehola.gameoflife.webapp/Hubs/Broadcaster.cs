using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace nehola.gameoflife.webapp.Hubs
{
    public class Broadcaster : Hub<IBroadcaster>
    {
        public override Task OnConnected()
        {
            // Set connection id for just connected client only
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }

        // Server side methods called from client
        public Task Subscribe(int id)
        {
            return Groups.Add(Context.ConnectionId, id.ToString());
        }

        public Task Unsubscribe(int id)
        {
            return Groups.Remove(Context.ConnectionId, id.ToString());
        }

        public async void GenerationUpdated(string world)
        {
            await Clients.All.GenerationUpdated(world);
        }
    }
}
