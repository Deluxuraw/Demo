using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CoordinateInput : MonoBehaviour
{

    public TMP_InputField longInput;
    public TMP_InputField latInput;

    public decimal latitude = 0;
    public decimal longtitude = 0;

    private void Start()
    {
        longInput.text = longtitude.ToString();
        latInput.text = latitude.ToString();

        longInput.onEndEdit.AddListener(delegate { ChangeLong(); });
        latInput.onEndEdit.AddListener(delegate { ChangeLat(); });
    }

    void ChangeLong()
    {
        decimal.TryParse(longInput.text, out longtitude);

        if (longtitude < -180M || longtitude > 180M)
        {
            longtitude = 0;
            Debug.LogError("The value for Longtitude must be between -180° and 180°.");
        }

        longInput.text = longtitude.ToString();
        
    }
    void ChangeLat()
    {
        decimal.TryParse(latInput.text, out latitude);
        if (latitude < -90M || latitude > 90M)
        {
            latitude = 0;
            Debug.LogError("The value for Latitude must be between -90° and 90°.");
        }

        latInput.text = latitude.ToString();
    } 
}
