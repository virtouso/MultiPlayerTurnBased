using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;

namespace Utility
{
    namespace Backend
    {
        public interface IUtilityWebRequest
        {
            public IObservable<(UnityWebRequest.Result, string, Dictionary<string, string>)> Post(string url,
                Dictionary<string, string> formData, Dictionary<string, string> headers);
        }

        public class UtilityWebRequest : IUtilityWebRequest
        {
            
            public IObservable<(UnityWebRequest.Result, string, Dictionary<string, string>)> Post(string url,Dictionary<string,string> formData ,Dictionary<string,string> headers)
            {
                return Observable.FromCoroutine<(UnityWebRequest.Result, string, Dictionary<string, string>)>((observer, cancellationToken) =>PostRequest(url,formData,headers,observer,cancellationToken));
            }
            
          private  IEnumerator PostRequest(string url, Dictionary<string, string> formData,
                Dictionary<string, string> requestHeaders, IObserver<(UnityWebRequest.Result,string,Dictionary<string,string>)> observer, CancellationToken cancellationToken)
            {
                using (UnityWebRequest webRequest = UnityWebRequest.Post(url, formData))
                {
                    foreach (var item in requestHeaders)
                    {
                        webRequest.SetRequestHeader(item.Key, item.Value);
                    }
                    
                    yield return webRequest.SendWebRequest();
                    var responseHeaders = webRequest.GetResponseHeaders();
                    var result =( webRequest.result,webRequest.downloadHandler.text,responseHeaders);

                    observer.OnNext(result);
                    observer.OnCompleted(); 
                }
            }

        
        }


    
        
        
    }
}