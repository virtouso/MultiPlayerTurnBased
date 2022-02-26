using SharedModels;
using PlayerAuthentication.Models;
using SharedModels.General.Types;
using SharedRepository;
using static SharedModels.Player;
using Newtonsoft.Json;

namespace PlayerAuthentication.Mediator
{
    public class PlayerAuthenticationMediator : IPlayerAuthenticationMediator
    {
        private readonly IMongoRepository _repository;

        public PlayerAuthenticationMediator(IMongoRepository mongoRepository)
        {
            _repository = mongoRepository;
        }

        public (int, string) BindServiceToPlayer(PlayerAuthenticationInput inputData)
        {

            var result = _repository.AddServiceToPlayer(inputData.TokenId, new Service(inputData.ServiceId, inputData.Email));
            if (result.Result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, JsonConvert.SerializeObject(result.Result.Item2));
            }

            return (500, null);
        }




        public (int, string) InitPlayerAsGuest(PlayerAuthenticationInput inputData)
        {

            // todo should be moved to database
            Player.Progress progress = new Player.Progress(20, 100, 0, 0);
            Identity identity = new Identity();
            Service service = null;
            var result = _repository.GetTokenForInitialPlayer(identity, service, progress).Result;

            if (result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, result.Item2);
            }

            return (500, null);

        }




        public (int, string) InitPlayerWithService(PlayerAuthenticationInput inputData)
        {
            Player.Progress progress = new Player.Progress(20, 100, 0, 0);
            Identity identity = new Identity();
            Service service = new Service(inputData.ServiceId, inputData.Email);
            var result = _repository.GetTokenForInitialPlayer(identity, service, progress).Result;
            if (result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, result.Item2);
            }
            return (500, null);
        }
    }
}
