using System.Collections;
using System.Collections.Generic;
using Configuration.Backend.General;
using UnityEngine;
using Zenject;


namespace Utility
{
    namespace Backend
    {
        public interface IUtilityBackendServices
        {
            
        }

        public class UtilityBackendServices
        {
            [Inject] private BackendRoutes _backendRoutes;

        }
    }
}