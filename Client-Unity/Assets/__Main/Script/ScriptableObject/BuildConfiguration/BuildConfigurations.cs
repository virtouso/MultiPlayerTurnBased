using System.Collections;
using System.Collections.Generic;
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
        }

        public class BuildConfigurations : ScriptableObject, IBuildConfigurations
        {
            [SerializeField] private BuildTypes _selectedBuildType;
            public BuildTypes SelectedBuildType => _selectedBuildType;

            [SerializeField] private PlatformTypes _selectedPlatformType;
            public PlatformTypes SelectedPlatformType => _selectedPlatformType;
            [SerializeField] private StoreTypes _selectedStoreType;
            public StoreTypes SelectedStoreType => _selectedStoreType;
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