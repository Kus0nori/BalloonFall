using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private int _score;
    public Text scoreNumber;

    private void OnEnable()
    {
        _score = 0;
        scoreNumber.text = "0";
    }

    public void AddPoints(float balloonScale)
    {
        _score += Mathf.RoundToInt(50 / balloonScale);
        scoreNumber.text = _score.ToString();
    }
}
