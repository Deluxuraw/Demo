using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DatePicker : MonoBehaviour
{

    public TextMeshProUGUI year;
    public TextMeshProUGUI month;
    public TextMeshProUGUI date;
    public DateTime selectedDateTime = DateTime.Now;

    // Start is called before the first frame update
    void Start()
    {
        if(selectedDateTime == null)
        {
            selectedDateTime = DateTime.Now;
        }
        RefreshSelectedDate();
    }

    public void AddYear()
    {
        selectedDateTime = selectedDateTime.AddYears(1);
        RefreshSelectedDate();
    }
    public void SubtractYear()
    {
        selectedDateTime = selectedDateTime.AddYears(-1);
        RefreshSelectedDate();
    }
    public void AddMonth()
    {
        selectedDateTime = selectedDateTime.AddMonths(1);
        RefreshSelectedDate();
    }
    public void SubtractMonth()
    {
        selectedDateTime = selectedDateTime.AddMonths(-1);
        RefreshSelectedDate();
    }
    public void AddDay()
    {
        selectedDateTime = selectedDateTime.AddDays(1);
        RefreshSelectedDate();
    }
    public void SubtractDay()
    {
        selectedDateTime = selectedDateTime.AddDays(-1);
        RefreshSelectedDate();
    }

    void RefreshSelectedDate()
    {
        year.text = selectedDateTime.Year.ToString();
        month.text = selectedDateTime.Month.ToString();
        date.text = selectedDateTime.Day.ToString();
    }
}
