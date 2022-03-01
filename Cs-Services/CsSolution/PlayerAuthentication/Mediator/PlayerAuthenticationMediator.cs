using SharedModels;
using PlayerAuthentication.Models;
using SharedModels.General.Types;
using SharedRepository;
using static SharedModels.Player;
using Newtonsoft.Json;
using SharedUtility.Jwt;
using MongoDB.Bson;
using SharedRepository.Repository.SqlRepository.EntityFrameworkdRepository;

namespace PlayerAuthentication.Mediator
{
    public class PlayerAuthenticationMediator : IPlayerAuthenticationMediator
    {
        private readonly IMongoRepository _repository;
        private readonly IJwtHelper _jwtHelper;
        private readonly MultiPlayerTurnBasedContext _dbContext;
        public PlayerAuthenticationMediator(IMongoRepository mongoRepository, IJwtHelper jwtHelper, MultiPlayerTurnBasedContext dbContext)
        {
            _repository = mongoRepository;
            _jwtHelper = jwtHelper;
            _dbContext = dbContext;
        }
         
        public (int, string) BindServiceToPlayer(PlayerAuthenticationInput inputData)
        {
            ObjectId? id = _jwtHelper.ValidateJwtToken(inputData.TokenId);

            if (id is null)
                return (400, null);

            var result = _repository.AddServiceToPlayer(ObjectId.Parse(inputData.TokenId), new Service(inputData.ServiceId, inputData.Email));
            if (result.Result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, JsonConvert.SerializeObject(result.Result.Item2));
            }

            return (500, null);
        }




        public (int, string, Progress) InitPlayerAsGuest(PlayerAuthenticationInput inputData)
        {

            // todo should be moved to database

            InitialProgress initialProgress= this._dbContext.InitialProgress.First();

            Player.Progress progress = new Player.Progress(initialProgress.Gold, initialProgress.Silver, initialProgress.Level, initialProgress.Experience);
            Identity identity = new Identity();
            Service service = null;
            var result = _repository.GetTokenForInitialPlayer(identity, service, progress).Result;

            if (result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, result.Item2.ToString(), result.Item3);
            }

            return (500, null, null);

        }




        public (int, string, Progress) InitPlayerWithService(PlayerAuthenticationInput inputData)
        {
            Player.Progress progress = new Player.Progress(20, 100, 0, 0);
            Identity identity = new Identity();
            Service service = new Service(inputData.ServiceId, inputData.Email);
            var result = _repository.GetTokenForInitialPlayer(identity, service, progress).Result;
            if (result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, result.Item2.ToString(), result.Item3);
            }
            return (500, null, null);
        }
    }
}
