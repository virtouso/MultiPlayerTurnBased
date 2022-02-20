using PlayerAuthentication.Models;
using SharedModels;
using SharedModels.General;
using SharedModels.General.Types;
using static SharedModels.Player;

namespace SharedRepository
{
    public interface IMongoRepository
    {
        public  Task< ReturnData<string>> GetTokenForGuestPlayer(Player.Tracking.Device deviceInfo , Progress initialProgress);
  
      
    }
}
