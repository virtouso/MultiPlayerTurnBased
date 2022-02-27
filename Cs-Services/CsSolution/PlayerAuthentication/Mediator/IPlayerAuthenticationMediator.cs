using PlayerAuthentication.Models;
using SharedModels.General.Types;
using static SharedModels.Player;

namespace PlayerAuthentication.Mediator
{
    public interface IPlayerAuthenticationMediator
    {
        (int, string,Progress ) InitPlayerAsGuest(PlayerAuthenticationInput inputData);
        (int, string, Progress) InitPlayerWithService(PlayerAuthenticationInput inputData);
        (int, string) BindServiceToPlayer(PlayerAuthenticationInput inputData);

    }
}
