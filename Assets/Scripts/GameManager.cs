using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static Vector3 ScreenBounds;
    public static bool GameIsActive;

    private void Awake()
    {
        Time.timeScale = 0f;
        ScoreSystem.CurrentLevel = 1;
    }

    private void Start()
    {
        if (Camera.main != null)
        {
            ScreenBounds =
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                    Camera.main.transform.position.z));
        }
    }
}
