using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Utility
{
    namespace AssetDownlaoder
    {


        public interface IUtilityAssetLoader
        {
            void LoadAssetByStringAddressAsync<T>(string address, Action<AsyncOperationHandle<T>> callback);

            void LoadAssetByAssetReferenceAsync<T>(AssetReference assetReference,
                Action<AsyncOperationHandle<T>> callback);

            T LoadAssetSync<T>(string address);
        }

        public class UtilityAddressables : IUtilityAssetLoader
        {
            public void LoadAssetByStringAddressAsync<T>(string address, Action<AsyncOperationHandle<T>> callback)
            {
                UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<T>(address).Completed += callback;
            }

            public void LoadAssetByAssetReferenceAsync<T>(AssetReference assetReference,
                Action<AsyncOperationHandle<T>> callback)
            {
                assetReference.LoadAssetAsync<T>().Completed += callback;
            }


            public T LoadAssetSync<T>(string address)
            {
                return UnityEngine.AddressableAssets.Addressables.LoadAsset<T>(address).Result;
            }

        }
    }
}
