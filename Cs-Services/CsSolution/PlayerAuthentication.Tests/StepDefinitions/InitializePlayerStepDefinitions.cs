using System;
using TechTalk.SpecFlow;

namespace PlayerAuthentication.Tests.StepDefinitions
{
    [Binding]
    public class InitializePlayerStepDefinitions
    {





        [Given(@"Auth Token Not Exist")]
        public void GivenAuthTokenNotExist()
        {
            throw new PendingStepException();
        }

        [Given(@"PlayerService Not Exists")]
        public void GivenPlayerServiceNotExists()
        {
            throw new PendingStepException();
        }

        [When(@"Ask To  Initialize Player Data")]
        public void WhenAskToInitializePlayerData()
        {
            throw new PendingStepException();
        }

        [Then(@"Return (.*) To The Player")]
        public void ThenReturnToThePlayer(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"Auth Token Exist")]
        public void GivenAuthTokenExist()
        {
            throw new PendingStepException();
        }

        [Given(@"Auth Token Is Not Expired")]
        public void GivenAuthTokenIsNotExpired()
        {
            throw new PendingStepException();
        }

        [When(@"Ask TO Intialize Player Data")]
        public void WhenAskTOIntializePlayerData()
        {
            throw new PendingStepException();
        }

        [Given(@"Auth Token Is Null")]
        public void GivenAuthTokenIsNull()
        {
            throw new PendingStepException();
        }

        [Given(@"No Service Id Is Sent")]
        public void GivenNoServiceIdIsSent()
        {
            throw new PendingStepException();
        }

        [When(@"Ask To Initialize Player Data As Guest and Set New Record To Database")]
        public void WhenAskToInitializePlayerDataAsGuestAndSetNewRecordToDatabase()
        {
            throw new PendingStepException();
        }

        [Then(@"IsGuest Is True And Return (.*) And Player Auth Token")]
        public void ThenIsGuestIsTrueAndReturnAndPlayerAuthToken(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"Service Id Is Not Null")]
        public void GivenServiceIdIsNotNull()
        {
            throw new PendingStepException();
        }

        [When(@"Try Find Player Record With Id Otherwise Assign New Record For The Player")]
        public void WhenTryFindPlayerRecordWithIdOtherwiseAssignNewRecordForThePlayer()
        {
            throw new PendingStepException();
        }

        [Then(@"Is Guest Is False Return (.*) To Player And Return Auth Token")]
        public void ThenIsGuestIsFalseReturnToPlayerAndReturnAuthToken(int p0)
        {
            throw new PendingStepException();
        }
    }
}
