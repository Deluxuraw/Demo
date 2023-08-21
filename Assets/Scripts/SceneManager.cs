using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.Timeline;
using Innovative.SolarCalculator;
using System.Drawing;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public DatePicker datePicker;
    public CoordinateInput coordinateInput;
    public Sun sunControl;
    public TimeSelect timeSelect;
    public GameObject playControl;

    Solar solar;
    bool isPlay = false;

    private void Awake()
    {
        ChangeSun();
        TogglePlayControlBtn();
    }

    public void OnClickPlay()
    {
        isPlay = true;
        ChangeSun();
        TogglePlayControlBtn();
    }   
    
    public void OnClickPause()
    {
        isPlay = false;
        TogglePlayControlBtn();
    }

    public void ChangeSun()
    {
        solar = new Solar();
        solar.Latitude = coordinateInput.latitude;
        solar.Longitude = coordinateInput.longtitude;

        DateTime dateTime = datePicker.selectedDateTime.Date;
        if (timeSelect.GetTime() < 86400)
        {
            TimeSpan ts = TimeSpan.FromSeconds(timeSelect.GetTime());
            dateTime = dateTime + ts;

        }
        solar.SolarDateTime = dateTime;

        sunControl.SetSolarTimes(solar.GetSolarTimes());
        sunControl.ChangeTime(timeSelect.GetTime(), dateTime.DayOfYear);
    }

    private void Update()
    {
        if(isPlay)
        {
            timeSelect.AddTime();
            ChangeSun();
        }
    }

    void TogglePlayControlBtn()
    {
        playControl.gameObject.transform.Find("Play").GetComponent<Button>().interactable = !isPlay;
        playControl.gameObject.transform.Find("Pause").GetComponent<Button>().interactable = isPlay;
    }

    public bool IsPlay { get { return isPlay; } }
}
