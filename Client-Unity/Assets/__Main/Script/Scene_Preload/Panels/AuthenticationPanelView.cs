
using Mvc;
using PreloadScene.SceneManagement;
using UnityEngine;



namespace PreloadScene.Authentications
{
    public class AuthenticationPanelModel : BaseModel
    {
        
    }

    public class AuthenticationPanelController : BaseController<AuthenticationPanelModel>
    {
        
    }

    public class AuthenticationPanelView : BaseView<AuthenticationPanelModel,AuthenticationPanelController>,IPanel
    {
        [SerializeField] private PanelNames _panelName;
        public PanelNames PanelName => _panelName;
    }
}