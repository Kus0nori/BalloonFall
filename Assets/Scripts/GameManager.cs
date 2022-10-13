using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector3 ScreenBounds;

    private void Awake()
    {
        Time.timeScale = 0f;
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
