using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeSelect : MonoBehaviour
{
    public Slider timeSlider;
    public Slider speedSlider;
    public TextMeshProUGUI timeInDay;
    public SceneManager sceneManager;
    public DatePicker datePicker;

    private float _time;

    public float GetTime()
    {
        return _time;
    }

    public void AddTime()
    {
        _time += Time.deltaTime * speedSlider.value;
        
        if(_time >= 86400)
        {
            _time = 0;
            datePicker.AddDay();
        }

        timeSlider.value = _time / 86400;
    }

    public void SetTime()
    {
        _time = timeSlider.value * 86400;
        if (_time == 86400)
        {
            timeInDay.text = "24:00";
        }
        else
        {
            TimeSpan currentTime = TimeSpan.FromSeconds(_time);
            string[] tempTime = currentTime.ToString().Split(":"[0]);
            timeInDay.text = tempTime[0] + ":" + tempTime[1];
        }
        
        if(!sceneManager.IsPlay)
        {
            sceneManager.ChangeSun();
        }
    }
}
