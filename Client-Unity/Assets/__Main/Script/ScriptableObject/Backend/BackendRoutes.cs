using System;
using System.Collections.Generic;
using System.Linq;
using Configuration.Enums;
using TurnBasedMultiPlayer.Enums.Backend;
using UnityEngine;


namespace Configuration
{
    namespace Backend
    {
        namespace General
        {
            public class BackendRoutes : ScriptableObject
            {
                public void Initialize(BackendTypes selectedBackendType)
                {
                    BackendServices = new Dictionary<ServiceNames, BackendService>(_backendServices.Count);
                    foreach (var item in _backendServices)
                    {
                        item.Init(selectedBackendType);
                        BackendServices.Add(item._serviceName, item);
                    }
                }

                public Dictionary<ServiceNames, BackendService> BackendServices;
                [SerializeField] private List<BackendService> _backendServices;


                [System.Serializable]
                public struct BackendService
                {
                    public void Init(BackendTypes backendType)
                    {
                        SelectedBackendUrl = _urlList.First(x => x._backendType == backendType);
                        Requests = new Dictionary<BackendRequestNames, ServerRequest>(_serverRequestsList.Count);
                        foreach (var item in _serverRequestsList)
                        {
                            Requests.Add(item.RequestName, item);
                        }
                    }

                    [SerializeField] public ServiceNames _serviceName;
                    [HideInInspector] public BackendUrl SelectedBackendUrl;
                    [HideInInspector] public Dictionary<BackendRequestNames, ServerRequest> Requests;

                    [SerializeField] private List<BackendUrl> _urlList;
                    [SerializeField] private List<ServerRequest> _serverRequestsList;


                    [System.Serializable]
                    public struct BackendUrl
                    {
                        [SerializeField] public BackendTypes _backendType;
                        [SerializeField] public string Url;
                    }

                    [Serializable]
                    public class ServerRequest
                    {
                        [SerializeField] public BackendRequestNames RequestName;
                        [SerializeField] public string _subQuery;
                        [SerializeField] public List<string> _requestFormKeys;
                        [SerializeField] public List<string> _headerKeys;
                    }
                }
            }
        }
    }

    namespace Enums
    {
        public enum ServiceNames
        {
            PlayerAuthentication,
            LeaderBoard,
            MatchMaking,
            AuthoritativeGamePlay
        }
    }
}