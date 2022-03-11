using System;
using System.Collections;
using System.Collections.Generic;
using Mvc;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


namespace PreloadScene
{
    namespace SceneManagement
    {
        public class MainSceneManagerModel : BaseModel
        {
        }

        public class MainSceneManagerController : BaseController<MainSceneManagerModel>
        {
            public void LoginSuccess((string, Dictionary<string, string> ) login)
            {
                //todo save data received or handle it somewhere better
                SceneManager.LoadScene(SceneNames.GameFlow);
            }
        }

        public class MainSceneManagerView : BaseView<MainSceneManagerModel, MainSceneManagerController>
        {
            [SerializeField] private Transform _panelsParent;
            private Dictionary<PanelNames, IPanel> _panels;
            [Inject] private SignalBus _signalBus;

            private void FindAllPanels()
            {
                _panels = new Dictionary<PanelNames, IPanel>(_panelsParent.childCount);
                foreach (var item in _panelsParent.GetComponentsInChildren<IPanel>())
                {
                    _panels.Add(item.PanelName, item);
                }
            }

            private void LoginSuccess((string, Dictionary<string, string>) input)
            {
                Debug.Log("message received");
                Controller.LoginSuccess(input);
            }


            protected override void Awake()
            {
                base.Awake();
                FindAllPanels();
            }

            private void Start()
            {
                _signalBus.Subscribe<(string, Dictionary<string, string>)>(LoginSuccess);
            }
        }

        public enum PanelNames
        {
            Downloader,
            Authentication
        }
    }
}