using PlayerAuthentication.Models;
using SharedModels;
using SharedModels.General;
using SharedModels.General.Types;
using SharedRepository.Models;
using static SharedModels.Player;

namespace SharedRepository
{
    public interface IMongoRepository
    {
        public  Task<(ResponseType, string)> GetTokenForInitialPlayer(Identity identity,Service service , Progress initialProgress);

        public Task<(ResponseType, Progress)> AddServiceToPlayer(string authToken ,Service service);

    }
}
