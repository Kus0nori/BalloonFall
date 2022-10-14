using System.Collections;
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
    private void Start()
    {
        _screenBounds = GameManager.ScreenBounds;
        StartCoroutine(CreateBalloon());
    }

    private IEnumerator CreateBalloon()
    {
        yield return new WaitForSeconds(1f);
        while (GameManager.GameIsActive)
        {
            _balloonScale = Random.Range(0.5f, 2f);
            _balloonRadius = _balloonScale / 2;
            _spawnXAxis = Random.Range(-_screenBounds.x+_balloonRadius, _screenBounds.x-_balloonRadius);
            _spawnRate = Random.Range(0.5f/ScoreSystem.CurrentLevel, 2f/ScoreSystem.CurrentLevel);
            _currBalloon = Instantiate(balloonPrefab, new Vector3(_spawnXAxis, _screenBounds.y+1f, 1f), Quaternion.identity);
            _currBalloon.transform.localScale = new Vector3(_balloonScale, _balloonScale, 1f);
            _currBalloon.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
