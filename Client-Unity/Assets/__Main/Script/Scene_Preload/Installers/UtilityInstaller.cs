using UnityEngine;
using Utility.Backend;
using Zenject;

public class UtilityInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IUtilityBackendServices>().To<UtilityBackendServices>().FromNew().AsSingle();
        Container.Bind<IUtilityWebRequest>().To<UtilityWebRequest>().FromNew().AsSingle();

    }
}