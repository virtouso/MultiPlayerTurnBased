using System;
using TechTalk.SpecFlow;

namespace PlayerAuthentication.Tests.StepDefinitions
{
    [Binding]
    public class InitializeGuestPlayerStepDefinitions
    {
        [Given(@"Device Id Is Not Null")]
        public void GivenDeviceIdIsNotNull()
        {
            throw new PendingStepException();
        }

        [Given(@"GooglePlay ID Is Null")]
        public void GivenGooglePlayIDIsNull()
        {
            throw new PendingStepException();
        }

        [When(@"Player Initial Model Submitted")]
        public void WhenPlayerInitialModelSubmitted()
        {
            throw new PendingStepException();
        }

        [Then(@"Temp Flag Is True And Temp Token Is Not Null")]
        public void ThenTempFlagIsTrueAndTempTokenIsNotNull()
        {
            throw new PendingStepException();
        }
    }
}
