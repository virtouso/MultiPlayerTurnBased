using System;
using System.Collections.Generic;
using System.Linq;
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
                    foreach (var item in BackendServices)
                    {
                        item.Init(selectedBackendType);
                    }
                }


                [SerializeField] private List<BackendService> BackendServices;


                [System.Serializable]
                public struct BackendService
                {
                    public void Init(BackendTypes backendType)
                    {
                        SelectedBackendUrl = _urlList.First(x => x._backendType == backendType);
                        Requests = new Dictionary<BackendRequestNames, ServerRequest>(_serverRequestsList.Count);
                        foreach (var item in _serverRequestsList)
                        {
                            Requests.Add(item.RequestName,item);
                        }
                    }


                    public BackendUrl SelectedBackendUrl;
                    public Dictionary<BackendRequestNames, ServerRequest> Requests;

                    [SerializeField] private List<BackendUrl> _urlList;
                    [SerializeField] private List<ServerRequest> _serverRequestsList;


                    [System.Serializable]
                    public struct BackendUrl
                    {
                        [SerializeField] public BackendTypes _backendType;
                        [SerializeField] public string Url;
                    }


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
}