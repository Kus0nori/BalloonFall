using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class TextureGenerator : MonoBehaviour
{
    public Texture2D[] ballTexture;
    private Color[] _pixelArray32;
    private Color[] _pixelArray64;
    private Color[] _pixelArray128;
    private Color[] _pixelArray256;
    private Thread _pixelArraysThread;
    private bool _changeColors;
    private Color[] _randomColor;
    private void Start()
    {
        _randomColor = new Color[4];
        ballTexture = new Texture2D[4];
        _pixelArraysThread = new Thread(GeneratePixelArray);
        _pixelArray32 = new Color[32*32];
        _pixelArray64 = new Color[64*64];
        _pixelArray128 = new Color[128*128];
        _pixelArray256 = new Color[256*256];
        GenerateTextureSet();
    }
    private void Update()
    {
        if (_pixelArraysThread.IsAlive || !_changeColors) return;
        ApplyPixelsToTextures();
        _pixelArraysThread = new Thread(GeneratePixelArray);
        _changeColors = false;
    }
    public void GenerateTextureSet()
    {
        for (var i = 0; i < _randomColor.Length; i++)
        {
            _randomColor[i] = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
        ballTexture[0] = null;
        ballTexture[1] = null;
        ballTexture[2] = null;
        ballTexture[3] = null;
        Resources.UnloadUnusedAssets();
        ballTexture[0] = new Texture2D(32, 32);
        ballTexture[1] = new Texture2D(64, 64);
        ballTexture[2] = new Texture2D(128, 128);
        ballTexture[3] = new Texture2D(256, 256);
        if (!_pixelArraysThread.IsAlive)
        {
            _pixelArraysThread.Start();
        }
    }
    private void ApplyPixelsToTextures()
    {
        ballTexture[0].SetPixels(_pixelArray32);
        ballTexture[0].Apply();
        ballTexture[1].SetPixels(_pixelArray64);
        ballTexture[1].Apply();
        ballTexture[2].SetPixels(_pixelArray128);
        ballTexture[2].Apply();
        ballTexture[3].SetPixels(_pixelArray256);
        ballTexture[3].Apply();
        Debug.Log("Applied!");
    }
    private void GeneratePixelArray()
    {
        for (var i = 0; i < _pixelArray32.Length; i++)
        {
            _pixelArray32[i] = _randomColor[0];
        }
        for (var i = 0; i < _pixelArray64.Length; i++)
        {
            _pixelArray64[i] = _randomColor[1];
        }
        for (var i = 0; i < _pixelArray128.Length; i++)
        {
            _pixelArray128[i] = _randomColor[2];
        }
        for (var i = 0; i < _pixelArray256.Length; i++)
        {
            _pixelArray256[i] = _randomColor[3];
        }
        _changeColors = true;
    }
}
