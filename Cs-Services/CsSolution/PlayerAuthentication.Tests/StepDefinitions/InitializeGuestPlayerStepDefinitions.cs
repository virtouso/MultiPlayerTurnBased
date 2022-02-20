using FluentValidation.Results;
using NSubstitute;
using NSubstitute.Core;
using PlayerAuthentication.Mediator;
using PlayerAuthentication.Models;
using SharedModels.General.Types;
using TechTalk.SpecFlow;

namespace PlayerAuthentication.Tests.StepDefinitions
{
    [Binding]
    public class InitializeGuestPlayerStepDefinitions
    {


        string _devideId = null;
        string _googlePlayId = null;

        ValidationResult _validationResult;

        Mediator.IPlayerAuthenticationMediator _mediator;
       PlayerAuthenticationInput _input;

    [BeforeScenario]
        public  void Setup()
        {
        _input = new PlayerAuthenticationInput("123456", "123", "123", "123456", "32312312332");

            _mediator = Substitute.For<IPlayerAuthenticationMediator>();
            _mediator.InitGuestPlayer(_input).Returns(new ReturnData<string>("123zxc123zxc"));
        }

     

        [Given(@"Device Id Is Not Null")]
        public void GivenDeviceIdIsNotNull()
        {

            _devideId = "123123123123123";
        }

        [Given(@"GooglePlay ID Is Null")]
        public void GivenGooglePlayIDIsNull()
        {
            _googlePlayId = null;
        }

        ReturnData<string> _tempToken;
       [When(@"Player Initial Model Submitted")]
        public void WhenPlayerInitialModelSubmitted()
        {
           
            _validationResult = _input.ModelValidator.Validate(_input);
            _tempToken = _mediator.InitGuestPlayer(_input);

        }

        [Then(@"Temp Flag Is True And Temp Token Is Not Null")]
        public void ThenTempFlagIsTrueAndTempTokenIsNotNull()
        {
            Assert.True(_validationResult.IsValid);
           Assert.Equal("123zxc123zxc", _tempToken.Data);

        }









        [Given(@"Device Id Is Not Valid")]
        public void GivenDeviceIdIsNotValid()
        {
            PlayerAuthenticationInput input = new PlayerAuthenticationInput("123", "123", "123", "123", null);
            _validationResult = input.ModelValidator.Validate(input);

        }

        [Then(@"Return initiation Invalid")]
        public void ThenReturnInitiationInvalid()
        {
            Assert.False(_validationResult.IsValid);
        }

        [AfterScenario]
        public void TearDown()
        {

        }





    }
}
