using UnityEngine;
using Zenject;

namespace Mvc
{
    
    public class MvcInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BaseModel>().FromNew().AsSingle();
            Container.Bind<BaseController<BaseModel>>().FromNew().AsSingle();
        }
    }
}