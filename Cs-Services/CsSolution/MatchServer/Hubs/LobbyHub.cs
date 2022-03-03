using Microsoft.AspNetCore.SignalR;

namespace MatchServer.Hubs
{



    public class LobbyHub:Hub
    {

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
