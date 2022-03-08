using System;
using System.Collections;
using System.Collections.Generic;
using Mvc;
using UnityEngine;
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
        }

        public class MainSceneManagerView : BaseView<MainSceneManagerModel, MainSceneManagerController>
        {
            [SerializeField] private Transform _panelsParent; 
            private Dictionary<PanelNames, IPanel> _panels;

            private void FindAllPanels()
            {
                _panels = new Dictionary<PanelNames, IPanel>(_panelsParent.childCount);
                foreach (var item in _panelsParent.GetComponentsInChildren<IPanel>())
                {
                    _panels.Add(item.PanelName,item); 
                }
                
            }
            
            
            protected override void Awake()
            {
                base.Awake();
                FindAllPanels();
            }

            private void Start()
            {
                Debug.Log(_panels.Count);
            }
        }
        
        public enum PanelNames{Downloader,Authentication}
        
    }
}