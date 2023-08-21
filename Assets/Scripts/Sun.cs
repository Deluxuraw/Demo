using Innovative.SolarCalculator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float time;
    public Transform sunTransform;
    public Light sun;
    public float intensity;

    SolarTimes solarTimes;
    float sunDegrees = 0;

    public void ChangeTime(float time, int dayOfYear)
    {
        ChangeSunRotate();
        ChangeSunIntensity(time);
        ChangeSunDistance(dayOfYear);
    }

    public void SetSolarTimes(SolarTimes solar)
    {
        solarTimes = solar;
        sunDegrees = 90 + solarTimes.HourAngleDegrees.Degrees;

        Debug.Log("EccentricityOfEarthOrbit" + solarTimes.EccentricityOfEarthOrbit);
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

    void ChangeSunDistance(int dayOfYear)
    {
        double c = 0.9856 * (dayOfYear - 4);
        double distance = 1 - double.Parse(solarTimes.EccentricityOfEarthOrbit.ToString()) * Math.Cos(c);


        //Debug.Log(distance);
        //Debug.Log(solarTimes.SunMeanAnomaly);
    }
}
