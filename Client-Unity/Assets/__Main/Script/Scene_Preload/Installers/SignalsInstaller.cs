using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PreloadScene
{
    namespace Installers
    {
        public class SignalsInstaller : MonoInstaller
        {
            public override void InstallBindings()
            {
                SignalBusInstaller.Install(Container);
                Container.DeclareSignal<(string,Dictionary< string,string>)>();
            }
        }
    }
}