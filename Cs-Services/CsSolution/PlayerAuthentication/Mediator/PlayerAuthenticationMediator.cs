using SharedModels;
using PlayerAuthentication.Models;
using SharedModels.General.Types;
using SharedRepository;




namespace PlayerAuthentication.Mediator
{
    public class PlayerAuthenticationMediator : IPlayerAuthenticationMediator
    {
        private readonly IMongoRepository _repository;

        public PlayerAuthenticationMediator(IMongoRepository mongoRepository)
        {
            _repository = mongoRepository;
        }

        public int BindServiceToPlayer(PlayerAuthenticationInput inputData)
        {
            throw new NotImplementedException();
        }

        public (int, string) InitPlayerAsGuest(PlayerAuthenticationInput inputData)
        {
            throw new NotImplementedException();
        }

        public (int, string) InitPlayerWithService(PlayerAuthenticationInput inputData)
        {
            throw new NotImplementedException();
        }
    }
}
