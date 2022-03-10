using System;
using System.Collections;
using System.Collections.Generic;
using Configuration.Backend.General;
using Configuration.Enums;
using SharedReferences;
using TurnBasedMultiPlayer.Enums.Backend;
using UniRx;
using UnityEngine;
using Zenject;


namespace Utility
{
    namespace Backend
    {
        public interface IUtilityBackendServices
        {
            IObservable<string> AuthorizePlayer(bool isGuest, string userId, string email, string tokenId,
                string authCode);
        }

        public class UtilityBackendServices : IUtilityBackendServices
        {
            [Inject] private BackendRoutes _backendRoutes;

            public IObservable<string> AuthorizePlayer(bool isGuest, string userId, string email, string tokenId, string authCode)
            {
                WWWForm content = new WWWForm();
                Dictionary<string, string> headers = new Dictionary<string, string>();

                content.AddField(RequestFieldNames.IsGuest,isGuest.ToString());
                content.AddField(RequestFieldNames.UserId,userId);
                content.AddField(RequestFieldNames.Email,email);
                content.AddField(RequestFieldNames.TokenId,tokenId);
                content.AddField(RequestFieldNames.AuthCode,authCode);
                string result = null;
                ObservableWWW.Post(_backendRoutes.BackendServices[ServiceNames.PlayerAuthentication].SelectedBackendUrl.Url
                                   + _backendRoutes.BackendServices[ServiceNames.PlayerAuthentication].Requests[BackendRequestNames.Login],
                        content,
                        headers)
                    .Subscribe(
                        x => { result = x; }
                    );
                return Observable.Return(result);
            }
        }
    }
}