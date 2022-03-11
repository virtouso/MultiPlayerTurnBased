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
         
   




        public (int, string, Progress) InitPlayerAsGuest(PlayerAuthenticationInput inputData)
        {

           

            InitialProgress initialProgress= this._dbContext.InitialProgress.First();

            Player.Progress progress = new Player.Progress(initialProgress.Gold, initialProgress.Silver, initialProgress.Level, initialProgress.Experience);
            Identity identity = new Identity();
         
            var result = _repository.InitializePlayer(inputData.IsGuest,identity,  progress).Result;

            if (result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, result.Item2.ToString(), result.Item3);
            }

            return (500, null, null);

        }




        public (int, string, Progress) InitPlayerWithService(PlayerAuthenticationInput inputData)
        {
            InitialProgress initialProgress = this._dbContext.InitialProgress.First();
            Identity identity = new Identity();
            Player.Progress progress = new Player.Progress(initialProgress.Gold, initialProgress.Silver, initialProgress.Level, initialProgress.Experience);

            var result = _repository.InitializePlayer(inputData.IsGuest,identity, progress).Result;
            if (result.Item1 == SharedRepository.Models.ResponseType.Success)
            {
                return (200, result.Item2.ToString(), result.Item3);
            }
            return (500, null, null);
        }
    }
}
