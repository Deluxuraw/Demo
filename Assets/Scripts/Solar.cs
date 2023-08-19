using Innovative.SolarCalculator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solar
{
    private DateTime _solarDateTime;
    private decimal _solarLat;
    private decimal _solarLong;

    public SolarTimes GetSolarTimes()
    {
        SolarTimes solarTimes = new SolarTimes(_solarDateTime, _solarLat, _solarLong);
        return solarTimes;
    }


    public decimal Longitude
    {
        get
        {
            return _solarLong;
        }
        set
        {
            if (value >= -180M && value <= 180M)
            {
                _solarLong = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The value for Longitude must be between -180° and 180°.");
            }
        }
    }

    public decimal Latitude
    {
        get
        {
            return _solarLat;
        }
        set
        {
            if (value >= -90M && value <= 90M)
            {
                _solarLat = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The value for Latitude must be between -90° and 90°.");
            }
        }
    }
    public DateTime SolarDateTime
    {
        get
        {
            return _solarDateTime;
        }
        set
        {
            _solarDateTime = value;
        }
    }


}
