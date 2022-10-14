using System;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    private Texture2D _ballTexture32;
    private Texture2D _ballTexture64;
    private Texture2D _ballTexture128;
    private Texture2D _ballTexture256;

    private void GenerateTextureSet()
    {
        _ballTexture32 = new Texture2D(32, 32);
        _ballTexture64 = new Texture2D(64, 64);
        _ballTexture128 = new Texture2D(128, 128);
        _ballTexture256 = new Texture2D(256, 256);
    }
}
