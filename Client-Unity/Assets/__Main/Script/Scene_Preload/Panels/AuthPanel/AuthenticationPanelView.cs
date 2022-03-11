using System;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Mvc;
using PreloadScene.SceneManagement;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility.Backend;
using Zenject;


namespace PreloadScene.Authentications
{
    public class AuthenticationPanelModel : BaseModel
    {
    }

    public class AuthenticationPanelController : BaseController<AuthenticationPanelModel>
    {
        private IUtilityBackendServices _backendServices;
        private SignalBus _signalBus;

        public override void SetupSecondary(params object[] input)
        {
            base.SetupSecondary(input);
            _backendServices = (IUtilityBackendServices)input[0];
            _signalBus = (SignalBus)input[1];
        }

        public void InitializeServices()
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
                .RequestServerAuthCode(false /* Don't force refresh */)
                .Build();

            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.Activate();
        }


        public void StartAsGuest()
        {
            _backendServices.AuthorizePlayer(true, "empty",
                "empty@mail.com", "null_token", "null_code")
                .SelectMany(x=>
                {
                     Debug.Log(x.Item2);
                     _signalBus.Fire<(string,Dictionary<string,string>)>((x.Item2,x.Item3));
                     return Observable.Return(true);
                }
                ).Subscribe();
        }

        public void StartGooglePlay()
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    string authCode = PlayGamesPlatform.Instance.GetServerAuthCode();
                    string email = PlayGamesPlatform.Instance.GetUserEmail();
                    string idToken = PlayGamesPlatform.Instance.GetIdToken();
                    string userId = PlayGamesPlatform.Instance.GetUserId();

                    // var result = 
                    //     _backendServices.AuthorizePlayer(false, userId, email, idToken, authCode)
                    //     .SelectMany().Subscribe();
                }
            });
        }
    }

    public class AuthenticationPanelView : BaseView<AuthenticationPanelModel, AuthenticationPanelController>, IPanel
    {
        [SerializeField] private PanelNames _panelName;
        public PanelNames PanelName => _panelName;

        [SerializeField] private Button _buttonGuest;
        [SerializeField] private Button _buttonGooglePlay;
        [Inject] private IUtilityBackendServices _backendServices;
        [Inject] private SignalBus _signalBus;
        private void Start()
        {
            Controller.SetupSecondary(_backendServices,_signalBus);
            Controller.InitializeServices();
            _buttonGuest.onClick.AddListener(Controller.StartAsGuest);
            _buttonGooglePlay.onClick.AddListener(Controller.StartGooglePlay);
        }
    }
}