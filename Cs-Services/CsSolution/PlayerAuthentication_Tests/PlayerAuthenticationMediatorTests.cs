using NUnit.Framework;
using PlayerAuthentication.Mediator;

namespace PlayerAuthentication_Tests
{
    internal class PlayerAuthenticationMediatorTests
    {

        PlayerAuthenticationMediator _mediator;

        [SetUp]
        public void SetUp() 
        
        {
            _mediator = new PlayerAuthenticationMediator();
        }


        [Test]
        public void TestMediator()
        {
          //  Assert.AreEqual("100", _mediator.GetDataAndGiveToken());
        }



    }
}
