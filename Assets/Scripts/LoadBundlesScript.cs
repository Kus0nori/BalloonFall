using System.Collections;
using UnityEngine;

public class LoadBundlesScript : MonoBehaviour
{
    private string _bundleURL;
    private int _version = 1;
    public GameObject backgroundManagerObject;
    private BackgroundManager _backgroundManager;
    private string[] _backgroundNames;

    private void Awake()
    {
        _bundleURL = Application.platform switch
        {
            RuntimePlatform.WindowsPlayer =>
                "https://github.com/Kus0nori/BalloonFall/blob/master/Assets/AssetBundles/Windows/content/backgrounds.unity3d?raw=true",
            RuntimePlatform.Android =>
                "https://github.com/Kus0nori/BalloonFall/blob/master/Assets/AssetBundles/Android/content/backgrounds.unity3d?raw=true",
            RuntimePlatform.IPhonePlayer =>
                "https://github.com/Kus0nori/BalloonFall/blob/master/Assets/AssetBundles/iOS/content/backgrounds.unity3d?raw=true",
            _ => _bundleURL
        };

        _backgroundManager = backgroundManagerObject.GetComponent<BackgroundManager>();
        _backgroundNames = new [] {"snowymountains.png", "foggy.png", "cityskyline.png", "bluemoon.png", "sunnyday.png", "graveyard.png"};
        StartCoroutine(DownloadAndCache());
    }
      
    private IEnumerator DownloadAndCache()
    {
        while (!Caching.ready)
            yield return null;
        var www = new WWW(_bundleURL);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        var assetBundle = www.assetBundle;
        for (var i = 0; i < _backgroundManager.backgrounds.Length; i++)
        {
            var spriteRequest = assetBundle.LoadAssetAsync(_backgroundNames[i], typeof(Sprite));
            _backgroundManager.backgrounds[i] = spriteRequest.asset as Sprite;
            yield return spriteRequest;
        }
    }
}
