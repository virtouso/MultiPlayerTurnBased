

using SharedModels;

namespace PlayerAuthentication.Mediator
{
    public class PlayerAuthenticationMediator : IPlayerAuthenticationMediator
    {
        private readonly SharedRepository.IMongoRepository _repository;

        public string GetDataAndGiveToken(PlayerAuthenticationInput input)
        {


            return _repository.FindPlayerId(input).Data;

        }
    }
}
