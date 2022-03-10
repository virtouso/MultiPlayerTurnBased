

using Configuration.Backend.General;
using Configuration.Build;
using UnityEngine;
using Zenject;

namespace PreloadScene
{

    namespace Installers
    {


        public class ScriptableObjectInstaller : MonoInstaller
        {
            [SerializeField] private BuildConfigurations _buildConfigurations;
            [SerializeField] private BackendRoutes _backendRoutes;


            public override void InstallBindings()
            {
                _backendRoutes.Initialize(_buildConfigurations.SelectedBackendType);
                Container.Bind<BackendRoutes>().FromScriptableObject(_backendRoutes).AsSingle();

            }
        }
    }
}