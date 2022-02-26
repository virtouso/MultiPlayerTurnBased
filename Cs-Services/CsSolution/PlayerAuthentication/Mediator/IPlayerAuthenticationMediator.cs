using PlayerAuthentication.Models;
using SharedModels.General.Types;

namespace PlayerAuthentication.Mediator
{
    public interface IPlayerAuthenticationMediator
    {
        (int, string) InitPlayerAsGuest(PlayerAuthenticationInput inputData);
        (int,string) InitPlayerWithService(PlayerAuthenticationInput inputData);
        int BindServiceToPlayer(PlayerAuthenticationInput inputData);

    }
}
