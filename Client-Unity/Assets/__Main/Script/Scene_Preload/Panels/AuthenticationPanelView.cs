using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Mvc;
using PreloadScene.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


namespace PreloadScene.Authentications
{
    public class AuthenticationPanelModel : BaseModel
    {
    }

    public class AuthenticationPanelController : BaseController<AuthenticationPanelModel>
    {
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
        }

        public void StartGooglePlay()
        {
        }
    }

    public class AuthenticationPanelView : BaseView<AuthenticationPanelModel, AuthenticationPanelController>, IPanel
    {
        [SerializeField] private PanelNames _panelName;
        public PanelNames PanelName => _panelName;

        [SerializeField] private Button _buttonGuest;
        [SerializeField] private Button _buttonGooglePlay;


        private void Start()
        {
            Controller.InitializeServices();
            _buttonGuest.onClick.AddListener(Controller.StartAsGuest);
            _buttonGooglePlay.onClick.AddListener(Controller.StartGooglePlay);
        }
    }
}