using System;
using System.Collections;
using UnityEngine;

public class LoadBundlesScript : MonoBehaviour
{
   /* private string _bundleURL = "file:://D:/Unity Projects/BalloonFall/Assets/AssetBundles/Windows/content/bakcgrounds.unity3d";
    private int _version = 0;
    [SerializeField] private Sprite[] _backgrounds;

    private void Awake()
    {
        StartCoroutine(DownloadAndCache());
    }
      
    private IEnumerator DownloadAndCache()
    {
        while (!Caching.ready)
            yield return null;
        var www = WWW.LoadFromCacheOrDownload(_bundleURL, _version);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        Debug.Log("Downloaded!");
        var assetBundle = www.assetBundle;
        var backgroundName = "moonBG.png";
        var spriteRequest = assetBundle.LoadAssetAsync(backgroundName, typeof(Sprite));
        yield return spriteRequest;
        Debug.Log("бэкграунд распакован!");

        _backgrounds[0] = spriteRequest.asset as Sprite;
        if (_backgrounds[0] != null)
        {
            Debug.Log("Что-то загрузило");
        }
    }*/
}
