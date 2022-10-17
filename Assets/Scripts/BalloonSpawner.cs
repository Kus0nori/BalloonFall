using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    private float _balloonScale;
    private GameObject _currBalloon;
    private Vector3 _screenBounds;
    private float _spawnXAxis;
    private float _spawnRate;
    private float _balloonRadius;
    private TextureGenerator _textureGenerator;
    private void Start()
    {
        _textureGenerator = GameObject.Find("GameManager").GetComponent<TextureGenerator>();
        _screenBounds = GameManager.ScreenBounds;
        StartCoroutine(CreateBalloon());
    }
    
    private IEnumerator CreateBalloon()
    {
        yield return new WaitForSeconds(1f);
        while (GameManager.GameIsActive)
        {
            _balloonScale = Random.Range(0.5f, 2.5f);
            _balloonRadius = _balloonScale / 2;
            _spawnXAxis = Random.Range(-_screenBounds.x+_balloonRadius, _screenBounds.x-_balloonRadius);
            _spawnRate = Random.Range(0.5f/ScoreSystem.CurrentLevel, 2f/ScoreSystem.CurrentLevel);
            _currBalloon = Instantiate(balloonPrefab, new Vector3(_spawnXAxis, _screenBounds.y+1f, 1f), Quaternion.identity);
            _currBalloon.transform.localScale = new Vector3(_balloonScale, _balloonScale, 1f);
            int textureSize;
            if (_balloonScale < 1)
            {
                textureSize = 0;
            }
            else if(_balloonScale >= 1 && _balloonScale < 1.5)
            {
                textureSize = 1;
            }
            else if (_balloonScale >= 1.5 && _balloonScale < 2)
            {
                textureSize = 2;
            }
            else
            {
                textureSize = 3;
            }
            _currBalloon.GetComponent<Renderer>().material.mainTexture = _textureGenerator.ballTexture[textureSize];
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}