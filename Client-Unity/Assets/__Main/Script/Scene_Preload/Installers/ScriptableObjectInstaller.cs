

using Configuration.Backend.General;
using UnityEngine;
using Zenject;

namespace PreloadScene
{

    namespace Installers
    {


        public class ScriptableObjectInstaller : MonoInstaller
        {
            [SerializeField] private BackendRoutes _backendRoutes;


            public override void InstallBindings()
            {
                Container.Bind<BackendRoutes>().FromScriptableObject(_backendRoutes).AsSingle();

            }
        }
    }
}