using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private int _score;
    public Text scoreNumber;
    public static int CurrentLevel;
    private int _scoreForNewLevel;
    public Text levelNumber;
    public GameObject newLevelPanel;
    private TextureGenerator _textureGenerator;
    private void Awake()
    {
        ResetScore();
        _textureGenerator = GameObject.Find("GameManager").GetComponent<TextureGenerator>();
    }

    private void Update()
    {
        if (!GameManager.GameIsActive)
        {
           ResetScore();
        }
        if (_score < _scoreForNewLevel) 
            return;
        IncreaseLevel();
    }

    public void AddPoints(float balloonScale)
    {
        _score += Mathf.RoundToInt(50 / balloonScale);
        scoreNumber.text = _score.ToString();
    }

    private void IncreaseLevel()
    {
        CurrentLevel++;
        levelNumber.text = CurrentLevel.ToString();
        _scoreForNewLevel += 1000;
        StartCoroutine(NewLevelMessage());
        _textureGenerator.GenerateTextureSet();
    }

    private IEnumerator NewLevelMessage()
    {
        Time.timeScale = 0f;
        newLevelPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        newLevelPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    private void ResetScore()
    {
        _score = 0;
        scoreNumber.text = "0";
        _scoreForNewLevel = 1000;
    }
}