using MatchServer.Model;
using Microsoft.AspNetCore.SignalR;

namespace MatchServer.Hubs
{
    public class MatchMakingHub: Hub
    {
        private readonly static MatchesReference _matches = new MatchesReference();



        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }




    }
}
