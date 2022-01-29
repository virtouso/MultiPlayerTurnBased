

using SharedModels;

namespace PlayerAuthentication.Mediator
{
    public interface IPlayerAuthenticationMediator
    {
      string  GetDataAndGiveToken(PlayerAuthenticationInput input);



    }
}
