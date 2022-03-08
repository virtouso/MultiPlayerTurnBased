using System.Collections;
using System.Collections.Generic;
using Mvc;
using PreloadScene.SceneManagement;
using UnityEngine;


namespace PreloadScene
{
    namespace AssetDownload
    {
        public class AssetDownloaderPanelModel : BaseModel
        {
        }

        public class AssetDownloaderPanelController : BaseController<AssetDownloaderPanelModel>
        {
        }

        public class AssetDownloaderPanelView : BaseView<AssetDownloaderPanelModel, AssetDownloaderPanelController>,IPanel
        {
            [SerializeField] private PanelNames _panelName;
            public PanelNames PanelName => _panelName;
        }
    }
}