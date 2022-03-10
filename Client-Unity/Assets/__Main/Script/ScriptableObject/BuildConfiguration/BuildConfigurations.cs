using System.Collections;
using System.Collections.Generic;
using TurnBasedMultiPlayer.Enums.Backend;
using UnityEngine;


namespace Configuration
{
    namespace Build
    {
        public interface IBuildConfigurations
        {
            BuildTypes SelectedBuildType { get; }
            PlatformTypes SelectedPlatformType { get; }
            StoreTypes SelectedStoreType { get; }
            BackendTypes SelectedBackendType { get; }
        }

        public class BuildConfigurations : ScriptableObject, IBuildConfigurations
        {
            [SerializeField] private BuildTypes _selectedBuildType;
            public BuildTypes SelectedBuildType => _selectedBuildType;

            
            [SerializeField] private PlatformTypes _selectedPlatformType;
            public PlatformTypes SelectedPlatformType => _selectedPlatformType;
            
            
            [SerializeField] private StoreTypes _selectedStoreType;
            public StoreTypes SelectedStoreType => _selectedStoreType;

            [SerializeField] private BackendTypes _selectedBackendType;
            public BackendTypes SelectedBackendType => _selectedBackendType;
        }


        public enum BuildTypes
        {
            Editor,
            Test,
            Production
        }

        public enum PlatformTypes
        {
            Android,
            Ios,
            Pc,
            Editor
        }

        public enum StoreTypes
        {
            Editor,
            GooglePlay,
            AppStore,
            CafeBazaar,
            IranApps,
            Myket
        }
    }
}