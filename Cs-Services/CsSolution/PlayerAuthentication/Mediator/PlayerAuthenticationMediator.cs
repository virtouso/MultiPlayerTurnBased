using SharedModels;
using PlayerAuthentication.Models;
using SharedModels.General.Types;
using static SharedModels.Player.Tracking;

namespace PlayerAuthentication.Mediator
{
    public class PlayerAuthenticationMediator : IPlayerAuthenticationMediator
    {
        private readonly SharedRepository.IMongoRepository _repository;

        public ReturnData<string> InitGuestPlayer(PlayerAuthenticationInput inputData)
        {
            Device device = new Device(inputData.DeviceId);

            //todo should read config form database
            Player.Progress progress = new Player.Progress(20, 100, 0, 0);

            return _repository.GetTokenForGuestPlayer(device, progress).Result;
        }
    }
}
