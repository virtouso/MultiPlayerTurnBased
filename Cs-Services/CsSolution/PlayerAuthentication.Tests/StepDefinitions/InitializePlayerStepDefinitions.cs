using PlayerAuthentication.Models;
using SharedRepository;
using System;
using TechTalk.SpecFlow;
using NSubstitute;
using PlayerAuthentication.Mediator;
using SharedUtility.Jwt;
using MongoDB.Bson;
using SharedModels;
using SharedRepository.Models;
using SharedRepository.Repository.SqlRepository.EntityFrameworkdRepository;



namespace PlayerAuthentication.Tests.StepDefinitions
{
    [Binding]
    public class InitializePlayerStepDefinitions
    {


        PlayerAuthenticationInput _testInput;
        Player.Progress _defaultProgress;
        IMongoRepository _mongoRepository;
        IPlayerAuthenticationMediator _mediator;
        IJwtHelper _jwtHelper;
        string _jwtToken;
        [BeforeScenario]
        public void Setup()
        {
            _jwtToken = "6212b3dae6f1a74b1457bdca";
            _testInput = new PlayerAuthenticationInput();

            _mongoRepository = Substitute.For<IMongoRepository>();
            _jwtHelper = Substitute.For<IJwtHelper>();
            _defaultProgress = new Player.Progress(10, 10, 10, 10);
            _jwtHelper.GenerateJwtToken(ObjectId.Parse(_jwtToken)).Returns("1234567");
            


     

        }



        (int, string, Player.Progress) _guestPlayerResult;

        [Given(@"Auth Token Not Exist")]
        public void GivenAuthTokenNotExist()
        {
            _testInput.AuthCode = null;

        }

        [Given(@"PlayerService Not Exists")]
        public void GivenPlayerServiceNotExists()
        {
            _testInput.Email = null;
        }

        [When(@"Ask To  Initialize Player Data")]
        public void WhenAskToInitializePlayerData()
        {
            _guestPlayerResult = _mediator.InitPlayerAsGuest(_testInput);
        }

        [Then(@"Return (.*) To The Player")]
        public void ThenReturnToThePlayer(int p0)
        {
            Assert.Equal(200, _guestPlayerResult.Item1);
        }






        (int, string, Player.Progress) _permanentPlayerResult;
        [Given(@"Auth Token Exist")]
        public void GivenAuthTokenExist()
        {
            _testInput.AuthCode = _jwtToken;
            _testInput.Email = "test@email.com";
        }

        [Given(@"Auth Token Is Not Expired")]
        public void GivenAuthTokenIsNotExpired()
        {
            var validated = _jwtHelper.ValidateJwtToken(_testInput.AuthCode);

        }

        [When(@"Ask TO Intialize Player Data")]
        public void WhenAskTOIntializePlayerData()
        {
            _permanentPlayerResult = _mediator.InitPlayerWithService(_testInput);
        }

        [Then(@"Return Success To Player For Update Player")]
        public void ReturnSuccessToPlayerForUpdatePlayer()
        {
            Assert.Equal(200, _permanentPlayerResult.Item1);
        }


        [Given(@"Auth Token Is Null")]
        public void GivenAuthTokenIsNull()
        {
            _testInput.AuthCode = null;
        }

        [Given(@"No Service Id Is Sent")]
        public void GivenNoServiceIdIsSent()
        {
            _testInput.Email = null;
            _testInput.AuthCode = null;
        }

        [When(@"Ask To Initialize Player Data As Guest and Set New Record To Database")]
        public void WhenAskToInitializePlayerDataAsGuestAndSetNewRecordToDatabase()
        {
            _guestPlayerResult = _mediator.InitPlayerAsGuest(_testInput);
        }

        [Then(@"IsGuest Is True And Return (.*) And Player Auth Token")]
        public void ThenIsGuestIsTrueAndReturnAndPlayerAuthToken(int p0)
        {
            Assert.Equal(_guestPlayerResult.Item1, 200);
            Assert.NotNull(_guestPlayerResult.Item2);
        }








        [Given(@"Service Id Is Not Null")]
        public void GivenServiceIdIsNotNull()
        {
            _testInput.TokenId = "1dsa2351dsa33xcxz";
        }

        [When(@"Try Find Player Record With Id Otherwise Assign New Record For The Player")]
        public void WhenTryFindPlayerRecordWithIdOtherwiseAssignNewRecordForThePlayer()
        {
            _permanentPlayerResult = _mediator.InitPlayerWithService(_testInput);
        }

        [Then(@"Is Guest Is False Return (.*) To Player And Return Auth Token")]
        public void ThenIsGuestIsFalseReturnToPlayerAndReturnAuthToken(int p0)
        {
            Assert.Equal(200, _permanentPlayerResult.Item1);
        }


        [AfterScenario]
        public void TearDown()
        {

        }


    }
}
