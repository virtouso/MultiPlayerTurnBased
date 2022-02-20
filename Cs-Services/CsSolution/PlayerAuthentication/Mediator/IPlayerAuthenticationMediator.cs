using PlayerAuthentication.Models;
using SharedModels.General.Types;

namespace PlayerAuthentication.Mediator
{
    public interface IPlayerAuthenticationMediator
    {
        ReturnData<string> InitGuestPlayer(PlayerAuthenticationInput inputData);
    }
}
