using FluentValidation.Results;
using PlayerAuthentication.Models;
using System;
using TechTalk.SpecFlow;

namespace PlayerAuthentication.Tests.StepDefinitions
{
    [Binding]
    public class InitializeGuestPlayerStepDefinitions
    {

        string _devideId = null;
        string _googlePlayId = null;

        ValidationResult _validationResult;

        Mediator.PlayerAuthenticationMediator _mediator = new Mediator.PlayerAuthenticationMediator();



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

        [When(@"Player Initial Model Submitted")]
        public void WhenPlayerInitialModelSubmitted()
        {
            PlayerAuthenticationInput input = new PlayerAuthenticationInput("123", "123", _googlePlayId, "123", _devideId);
            _validationResult = input.ModelValidator.Validate(input);
            string tempToken= _mediator.GetTokenForGuestPlayer(input)

        }

        [Then(@"Temp Flag Is True And Temp Token Is Not Null")]
        public void ThenTempFlagIsTrueAndTempTokenIsNotNull()
        {
            Assert.True(_validationResult.IsValid);


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
    }
}
