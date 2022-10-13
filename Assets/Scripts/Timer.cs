using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float _currentTime;
    private TimeSpan _time;
    private void OnEnable()
    {
        _currentTime = 0f;
        _time = TimeSpan.Zero;
        timer.text = "00:00";
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        _time = TimeSpan.FromSeconds(_currentTime);
        timer.text = _time.ToString(@"mm\:ss");
    }
}
