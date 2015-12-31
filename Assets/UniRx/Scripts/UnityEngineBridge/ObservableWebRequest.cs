using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Networking;

#if !UniRxLibrary
using ObservableUnity = UniRx.Observable;
#endif

namespace UniRx
{
#if (UNITY_5_3)

    using Hash = System.Collections.Generic.Dictionary<string, string>;

    public static class ObservableWebRequest
    {
        #region Get

        public static IObservable<string> Get(string url, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<string>((observer, cancellation) =>
                FetchText(UnityWebRequest.Get(url), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<byte[]> GetAndGetBytes(string url, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<byte[]>((observer, cancellation) =>
                FetchBytes(UnityWebRequest.Get(url), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<UnityWebRequest> GetAndGetWebRequest(string url, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Get(url), (headers ?? new Hash()), observer, progress, cancellation));
        }

        #endregion

        #region GetTexture

        public static IObservable<Texture> GetTexture(string url, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<Texture>((observer, cancellation) =>
                FetchTexture(UnityWebRequest.GetTexture(url), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<Texture> GetTexture(string url, bool nonReadable, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<Texture>((observer, cancellation) =>
                FetchTexture(UnityWebRequest.GetTexture(url, nonReadable), (headers ?? new Hash()), observer, progress, cancellation));
        }

        #endregion

        #region GetAssetBundle

        public static IObservable<AssetBundle> GetAssetBundle(string url, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<AssetBundle>((observer, cancellation) =>
                FetchAssetBundle(UnityWebRequest.GetAssetBundle(url), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, uint crc, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<AssetBundle>((observer, cancellation) =>
                FetchAssetBundle(UnityWebRequest.GetAssetBundle(url, crc), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, uint version, uint crc, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<AssetBundle>((observer, cancellation) =>
                FetchAssetBundle(UnityWebRequest.GetAssetBundle(url, version, crc), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<AssetBundle> GetAssetBundle(string url, Hash128 hash128, uint crc, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<AssetBundle>((observer, cancellation) =>
                FetchAssetBundle(UnityWebRequest.GetAssetBundle(url, hash128, crc), (headers ?? new Hash()), observer, progress, cancellation));
        }

        #endregion

        #region Post

        public static IObservable<string> Post(string url, string postData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<string>((observer, cancellation) =>
                FetchText(UnityWebRequest.Post(url, postData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<string> Post(string url, WWWForm content, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<string>((observer, cancellation) =>
                FetchText(UnityWebRequest.Post(url, content), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<string> Post(string url, List<IMultipartFormSection> multipartFormSections, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<string>((observer, cancellation) =>
                FetchText(UnityWebRequest.Post(url, multipartFormSections), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<string> Post(string url, List<IMultipartFormSection> multipartFormSections, byte[] boundary, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<string>((observer, cancellation) =>
                FetchText(UnityWebRequest.Post(url, multipartFormSections, boundary), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, string postData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<byte[]>((observer, cancellation) =>
                FetchBytes(UnityWebRequest.Post(url, postData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, WWWForm content, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<byte[]>((observer, cancellation) =>
                FetchBytes(UnityWebRequest.Post(url, content), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, List<IMultipartFormSection> multipartFormSections, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<byte[]>((observer, cancellation) =>
                FetchBytes(UnityWebRequest.Post(url, multipartFormSections), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<byte[]> PostAndGetBytes(string url, List<IMultipartFormSection> multipartFormSections, byte[] boundary, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<byte[]>((observer, cancellation) =>
                FetchBytes(UnityWebRequest.Post(url, multipartFormSections, boundary), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<UnityWebRequest> PostAndGetWebRequest(string url, string postData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Post(url, postData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<UnityWebRequest> PostAndGetWebRequest(string url, WWWForm content, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Post(url, content), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<UnityWebRequest> PostAndGetWebRequest(string url, List<IMultipartFormSection> multipartFormSections, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Post(url, multipartFormSections), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<UnityWebRequest> PostAndGetWebRequest(string url, List<IMultipartFormSection> multipartFormSections, byte[] boundary, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Post(url, multipartFormSections, boundary), (headers ?? new Hash()), observer, progress, cancellation));
        }

        #endregion

        #region Put

        public static IObservable<string> Put(string url, string bodyData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<string>((observer, cancellation) =>
                FetchText(UnityWebRequest.Put(url, bodyData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<string> Put(string url, byte[] bodyData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<string>((observer, cancellation) =>
                FetchText(UnityWebRequest.Put(url, bodyData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<byte[]> PutAndGetBytes(string url, string bodyData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<byte[]>((observer, cancellation) =>
                FetchBytes(UnityWebRequest.Put(url, bodyData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<byte[]> PutAndGetBytes(string url, byte[] bodyData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<byte[]>((observer, cancellation) =>
                FetchBytes(UnityWebRequest.Put(url, bodyData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<UnityWebRequest> PutAndGetWebRequest(string url, string bodyData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Put(url, bodyData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        public static IObservable<UnityWebRequest> PutAndGetWebRequest(string url, byte[] bodyData, Hash headers = null, IProgress<float> progress = null)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Put(url, bodyData), (headers ?? new Hash()), observer, progress, cancellation));
        }

        #endregion

        #region Delete

        public static IObservable<UnityWebRequest> DeleteAndGetWebRequest(string url)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Delete(url), new Hash(), observer, null, cancellation));
        }

        #endregion

        #region Head

        public static IObservable<UnityWebRequest> HeadAndGetWebRequest(string url)
        {
            return ObservableUnity.FromCoroutine<UnityWebRequest>((observer, cancellation) =>
                Fetch(UnityWebRequest.Head(url), new Hash(), observer, null, cancellation));
        }

        #endregion

        #region Coroutine

        static IEnumerator Fetch(UnityWebRequest request, Hash headers, IObserver<UnityWebRequest> observer, IProgress<float> reportProgress, CancellationToken cancel)
        {
            using (request)
            {
                if (reportProgress != null)
                {
                    while (!request.isDone && !cancel.IsCancellationRequested)
                    {
                        try
                        {
                            reportProgress.Report(GetProgress(request));
                        }
                        catch (Exception ex)
                        {
                            observer.OnError(ex);
                            yield break;
                        }
                        yield return null;
                    }
                }
                else
                {
                    if (!request.isDone)
                    {
                        foreach (var header in headers)
                        {
                            request.SetRequestHeader(header.Key, header.Value);
                        }
                        yield return request.Send();
                    }
                }

                if (cancel.IsCancellationRequested) yield break;

                if (reportProgress != null)
                {
                    try
                    {
                        reportProgress.Report(GetProgress(request));
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                        yield break;
                    }
                }

                if (!string.IsNullOrEmpty(request.error))
                {
                    observer.OnError(new WebRequestErrorException(request));
                }
                else
                {
                    observer.OnNext(request);
                    observer.OnCompleted();
                }
            }
        }

        static IEnumerator FetchText(UnityWebRequest request, Hash headers, IObserver<string> observer, IProgress<float> reportProgress, CancellationToken cancel)
        {
            using (request)
            {
                if (reportProgress != null)
                {
                    while (!request.isDone && !cancel.IsCancellationRequested)
                    {
                        try
                        {
                            reportProgress.Report(GetProgress(request));
                        }
                        catch (Exception ex)
                        {
                            observer.OnError(ex);
                            yield break;
                        }
                        yield return null;
                    }
                }
                else
                {
                    if (!request.isDone)
                    {
                        foreach (var header in headers)
                        {
                            request.SetRequestHeader(header.Key, header.Value);
                        }
                        yield return request.Send();
                    }
                }

                if (cancel.IsCancellationRequested) yield break;

                if (reportProgress != null)
                {
                    try
                    {
                        reportProgress.Report(GetProgress(request));
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                        yield break;
                    }
                }

                if (!string.IsNullOrEmpty(request.error))
                {
                    observer.OnError(new WebRequestErrorException(request));
                }
                else
                {
                    var handler = request.downloadHandler;
                    var text = (handler != null) ? handler.text : null;
                    observer.OnNext(text);
                    observer.OnCompleted();
                }
            }
        }

        static IEnumerator FetchBytes(UnityWebRequest request, Hash headers, IObserver<byte[]> observer, IProgress<float> reportProgress, CancellationToken cancel)
        {
            using (request)
            {
                if (reportProgress != null)
                {
                    while (!request.isDone && !cancel.IsCancellationRequested)
                    {
                        try
                        {
                            reportProgress.Report(GetProgress(request));
                        }
                        catch (Exception ex)
                        {
                            observer.OnError(ex);
                            yield break;
                        }
                        yield return null;
                    }
                }
                else
                {
                    if (!request.isDone)
                    {
                        foreach (var header in headers)
                        {
                            request.SetRequestHeader(header.Key, header.Value);
                        }
                        yield return request.Send();
                    }
                }

                if (cancel.IsCancellationRequested) yield break;

                if (reportProgress != null)
                {
                    try
                    {
                        reportProgress.Report(GetProgress(request));
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                        yield break;
                    }
                }

                if (!string.IsNullOrEmpty(request.error))
                {
                    observer.OnError(new WebRequestErrorException(request));
                }
                else
                {
                    var handler = request.downloadHandler;
                    var data = (handler != null) ? handler.data : null;
                    observer.OnNext(data);
                    observer.OnCompleted();
                }
            }
        }

        static IEnumerator FetchTexture(UnityWebRequest request, Hash headers, IObserver<Texture> observer, IProgress<float> reportProgress, CancellationToken cancel)
        {
            using (request)
            {
                if (reportProgress != null)
                {
                    while (!request.isDone && !cancel.IsCancellationRequested)
                    {
                        try
                        {
                            reportProgress.Report(GetProgress(request));
                        }
                        catch (Exception ex)
                        {
                            observer.OnError(ex);
                            yield break;
                        }
                        yield return null;
                    }
                }
                else
                {
                    if (!request.isDone)
                    {
                        foreach (var header in headers)
                        {
                            request.SetRequestHeader(header.Key, header.Value);
                        }
                        yield return request.Send();
                    }
                }

                if (cancel.IsCancellationRequested) yield break;

                if (reportProgress != null)
                {
                    try
                    {
                        reportProgress.Report(GetProgress(request));
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                        yield break;
                    }
                }

                if (!string.IsNullOrEmpty(request.error))
                {
                    observer.OnError(new WebRequestErrorException(request));
                }
                else
                {
                    var handler = request.downloadHandler as DownloadHandlerTexture;
                    var texture = (handler != null) ? handler.texture : null;
                    observer.OnNext(texture);
                    observer.OnCompleted();
                }
            }
        }

        static IEnumerator FetchAssetBundle(UnityWebRequest request, Hash headers, IObserver<AssetBundle> observer, IProgress<float> reportProgress, CancellationToken cancel)
        {
            using (request)
            {
                if (reportProgress != null)
                {
                    while (!request.isDone && !cancel.IsCancellationRequested)
                    {
                        try
                        {
                            reportProgress.Report(GetProgress(request));
                        }
                        catch (Exception ex)
                        {
                            observer.OnError(ex);
                            yield break;
                        }
                        yield return null;
                    }
                }
                else
                {
                    if (!request.isDone)
                    {
                        foreach (var header in headers)
                        {
                            request.SetRequestHeader(header.Key, header.Value);
                        }
                        yield return request.Send();
                    }
                }

                if (cancel.IsCancellationRequested) yield break;

                if (reportProgress != null)
                {
                    try
                    {
                        reportProgress.Report(GetProgress(request));
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                        yield break;
                    }
                }

                if (!string.IsNullOrEmpty(request.error))
                {
                    observer.OnError(new WebRequestErrorException(request));
                }
                else
                {
                    var handler = request.downloadHandler as DownloadHandlerAssetBundle;
                    var assetBundle = (handler != null) ? handler.assetBundle : null;
                    observer.OnNext(assetBundle);
                    observer.OnCompleted();
                }
            }
        }

        static float GetProgress(UnityWebRequest request)
        {
            switch (request.method)
            {
                case UnityWebRequest.kHttpVerbGET:
                    return request.downloadProgress;

                case UnityWebRequest.kHttpVerbPOST:
                case UnityWebRequest.kHttpVerbPUT:
                    return request.uploadProgress;

                default:
                    return 0F; // To be considered.
            }
        }

        #endregion
    }

    public class WebRequestErrorException : Exception
    {
        public string RawErrorMessage { get; private set; }
        public bool HasResponse { get; private set; }
        public string Text { get; private set; }
        public System.Net.HttpStatusCode StatusCode { get; private set; }
        public System.Collections.Generic.Dictionary<string, string> ResponseHeaders { get; private set; }
        public UnityWebRequest WebRequest { get; private set; }
        public string Method { get; private set; }

        public WebRequestErrorException(UnityWebRequest request)
        {
            this.WebRequest = request;
            this.Method = request.method;
            this.RawErrorMessage = request.error;
            this.ResponseHeaders = request.GetResponseHeaders();
            this.HasResponse = false;
            this.StatusCode = (System.Net.HttpStatusCode)request.responseCode;

            var splitted = RawErrorMessage.Split(' ', ':');
            if (splitted.Length != 0)
            {
                int statusCode;
                if (int.TryParse(splitted[0], out statusCode))
                {
                    this.HasResponse = true;
                    //this.StatusCode = (System.Net.HttpStatusCode)statusCode;
                }
            }

            var handler = request.downloadHandler;
            if (handler != null && handler.GetType() != typeof(DownloadHandlerAssetBundle)) // DownloadHandlerAssetBundle will thorw a NotSupportedException if text property is called.
            {
                this.Text = request.downloadHandler.text; // cache the text because if www was disposed, can't access it.
            }
        }

        public override string ToString()
        {
            var text = this.Text;
            if (string.IsNullOrEmpty(text))
            {
                return RawErrorMessage;
            }
            else
            {
                return RawErrorMessage + " " + text;
            }
        }
    }

#endif
}