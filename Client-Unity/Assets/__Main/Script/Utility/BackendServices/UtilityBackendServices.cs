using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Configuration.Backend.General;
using Configuration.Enums;
using SharedReferences;
using TurnBasedMultiPlayer.Enums.Backend;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;


namespace Utility
{
    namespace Backend
    {
        public interface IUtilityBackendServices
        {
            IObservable<(UnityWebRequest.Result, string, Dictionary<string, string>)> AuthorizePlayer(bool isGuest,
                string userId, string email, string tokenId,
                string authCode);
        }

        public class UtilityBackendServices : IUtilityBackendServices
        {
            [Inject] private BackendRoutes _backendRoutes;
            [Inject] private IUtilityWebRequest _utilityWebRequest;

            public IObservable<(UnityWebRequest.Result, string, Dictionary<string, string>)> AuthorizePlayer(
                bool isGuest, string userId, string email, string tokenId,
                string authCode)
            {
                Dictionary<string, string> content = new Dictionary<string, string>();
                Dictionary<string, string> headers = new Dictionary<string, string>();

                content.Add(RequestFieldNames.IsGuest, isGuest.ToString());
                content.Add(RequestFieldNames.UserId, userId);
                content.Add(RequestFieldNames.Email, email);
                content.Add(RequestFieldNames.TokenId, tokenId);
                content.Add(RequestFieldNames.AuthCode, authCode);

                (UnityWebRequest.Result, string, Dictionary<string, string>) result = (
                    UnityWebRequest.Result.ConnectionError, null, null);

                string requestUrl = _backendRoutes.BackendServices[ServiceNames.PlayerAuthentication].SelectedBackendUrl
                                        .Url
                                    + _backendRoutes.BackendServices[ServiceNames.PlayerAuthentication]
                                        .Requests[BackendRequestNames.Login]._subQuery;

                return _utilityWebRequest.Post(requestUrl, content, headers);
                
            }
        }
    }
}