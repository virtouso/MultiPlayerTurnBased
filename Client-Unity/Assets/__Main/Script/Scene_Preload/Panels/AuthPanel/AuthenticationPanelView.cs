using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Mvc;
using PreloadScene.SceneManagement;
using UniRx;
using UnityEngine;
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


        public override void SetupSecondary(params object[] input)
        {
            base.SetupSecondary(input);
            _backendServices = (IUtilityBackendServices)input[0];
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
            var result = _backendServices.AuthorizePlayer(true, "empty", "empty@mail.com", "null_token", "null_code")
                .Do(x =>
                {
                    if (x != null)
                    {
                        Debug.Log("Request Success");
                        SceneManager.LoadScene(SceneNames.GameFlow);
                    }

                    else
                    {
                        Debug.Log("Request Failed");
                    }
                }).DoOnError(x => { Debug.Log("Request Failed"); });
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

                    var result = _backendServices.AuthorizePlayer(false, userId, email, idToken, authCode)
                        .Do(x =>
                        {
                            if (x != null)
                            {
                                Debug.Log("Request Success");
                                SceneManager.LoadScene(SceneNames.GameFlow);
                            }

                            else
                            {
                                Debug.Log("Request Failed");
                            }
                        }).DoOnError(x => { Debug.Log("Request Failed"); });
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

        private void Start()
        {
            Controller.SetupSecondary(_backendServices);
            Controller.InitializeServices();
            _buttonGuest.onClick.AddListener(Controller.StartAsGuest);
            _buttonGooglePlay.onClick.AddListener(Controller.StartGooglePlay);
        }
    }
}