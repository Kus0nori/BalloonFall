using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject score;
    public GameObject timer;
    
    public void StartGame()
    {
        startButton.SetActive(false);
        score.SetActive(true);
        timer.SetActive(true);
        stopButton.SetActive(true);
        Time.timeScale = 1f;
        GameManager.GameIsActive = true;
    }

    public void StopGame()
    {
        GameManager.GameIsActive = false;
        startButton.SetActive(true);
        score.SetActive(false);
        timer.SetActive(false);
        stopButton.SetActive(false);
        ScoreSystem.CurrentLevel = 1;
        Time.timeScale = 0f;
    }
}
