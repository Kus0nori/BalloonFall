using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject score;
    public GameObject timer;
    public static bool GameIsActive;
    
    public void StartGame()
    {
        startButton.SetActive(false);
        score.SetActive(true);
        timer.SetActive(true);
        stopButton.SetActive(true);
        Time.timeScale = 1f;
        GameIsActive = true;
    }

    public void StopGame()
    {
        GameIsActive = false;
        startButton.SetActive(true);
        score.SetActive(false);
        timer.SetActive(false);
        stopButton.SetActive(false);
        Time.timeScale = 0f;
    }
}
