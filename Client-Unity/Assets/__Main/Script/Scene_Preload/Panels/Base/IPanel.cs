using System.Collections;
using System.Collections.Generic;
using PreloadScene.SceneManagement;
using UnityEngine;
using Zenject;

namespace PreloadScene
{
    public interface IPanel
    {
        PanelNames PanelName { get; }
    }
}