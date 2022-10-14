using UnityEngine;

public class BalloonController : MonoBehaviour
{
    private float _balloonScale;
    private Vector3 _screenBounds;
    private float _balloonRadius;
    private float _fallingSpeed;
    private ScoreSystem _scoreSystem;
    private void Start()
    {
        var scoreGameObject = GameObject.Find("GameManager");
        _scoreSystem = scoreGameObject.GetComponent<ScoreSystem>();
        _balloonScale = transform.localScale.x;
        _balloonRadius = _balloonScale / 2;
        _screenBounds = GameManager.ScreenBounds;
        _fallingSpeed = 5 / _balloonScale;
    }
    
    private void Update()
    {
        transform.Translate(Vector3.down * (Time.deltaTime * _fallingSpeed * ScoreSystem.CurrentLevel));
        if (transform.position.y + _balloonRadius < -_screenBounds.y || !GameManager.GameIsActive)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        _scoreSystem.AddPoints(_balloonScale);
        Destroy(gameObject);
    }
}
