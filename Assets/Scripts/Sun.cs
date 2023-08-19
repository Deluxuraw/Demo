using Innovative.SolarCalculator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float time;
    public TimeSpan currentTime;
    public Transform sunTransform;
    public Light sun;
    public int days;
    public float intensity;
    public int speed;

    SolarTimes solarTimes;
    float sunDegrees = 0;

    void Update()
    {
        //ChangeTime();
    }

    public void ChangeTime(float time)
    {
        //time += Time.deltaTime * speed;

        //if(time > 86400) // 86400 seconds a day
        //{
        //    days += 1;
        //    time = 0;
        //}

        ChangeSunRotate();
        ChangeSunIntensity(time);
    }

    public void SetSolarTimes(SolarTimes solar)
    {
        solarTimes = solar;
        sunDegrees = 90 + solarTimes.HourAngleDegrees.Degrees;
    }

    void ChangeSunRotate()
    {
        float sunRotateX = sunDegrees;
        sunTransform.rotation = Quaternion.Euler(new Vector3(sunRotateX, 0, 0));
    }

    void ChangeSunIntensity(float time)
    {
        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 43200;
        }
        else
        {
            intensity = 1 - (43200 - time) / 43200 * -1;
        }

        sun.intensity = intensity;
    }
}
