﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//https://gist.github.com/ginomessmer/c160fb0591271d5818674fad466db40c
public class WorldTime : MonoBehaviour
{
    public DateTime WORLDTIME;          //ACCESSIBLE worldTime, many items will need access to this time
    float DayDuration;                  //Percentage of time a day takes in relation to 24 hour standard day, eg 50% would mean it takes 12 hours for an in game day
    public float timeMultiplier;        //How much faster (by multiplication) in game time is compared to real world time
    float deltaTimeHolder;              //The number of seconds (and miliseconds), that have passed in real time that hasnt been added to in game time
    Light sceneLight;

    public int lastHour;
    /*Day Durations: 
     * 12 hours,        50
     * 6 hours,         25
     * 3 hours,         12.5
     * 1.5 hours,       6.75
     * 1 hour,          4.1666666
     * 45 minutes,      3.375
     * 22.5 minutes,    1.6875
     */


    void Awake()
    {
        sceneLight = transform.GetChild(0).GetComponent<Light>();
        //Sets new default time
        if (WORLDTIME == DateTime.MinValue)
        {
            WORLDTIME = new DateTime(2019, 3, 8, 12, 00, 00);
        }
        //Sets the day duration holder (A percentage out of 100 for how long the day should be)
        DayDuration = 1.5625f;//0.09765625f;  1.5625f;
        //The multiplier for time. In game time by using the world time multiplied by this number
        timeMultiplier = 100 / DayDuration;
        lastHour = WORLDTIME.Hour;
    }
    void Update()
    {
        //Number of seconds multiplied by multiplier
        deltaTimeHolder += (Time.deltaTime * timeMultiplier);
        //The number of whole in game seconds have passed, (INT)
        int division = (int)deltaTimeHolder / 1;
        //Reduce deltaTimeHolder to reflect the time added to the ingame time
        deltaTimeHolder -= (float)division;
        //Add the number of seconds to the in game time
        WORLDTIME = WORLDTIME.AddSeconds(division);
        if(lastHour != WORLDTIME.Hour)
        {
            string printTime = "WorldTime: <color=navy>\tCurrentTime: " + WORLDTIME.Hour + ":" + WORLDTIME.Minute + "</color>";
            Debug.Log(printTime, this);
            //Debug.Log("<color=yellow>AI message: Acquiring new target</color>", this);
            lastHour = WORLDTIME.Hour;
            setLight();
        }
    }

    private void setLight()
    {
        int hr = WORLDTIME.Hour;
        //Debug.Log(hr >= 20);
        if(hr >= 20)
        {
            sceneLight.color = new Color(0.0313725f, 0f, 0.9176470f, 255f);
        }
        else if (hr < 6)
        {
            sceneLight.color = new Color(0.0313725f, 0f, 0.9176470f, 255f);
        }
        else
        {
            sceneLight.color = new Color(0.9176470f, 0.6705882f, 0f, 255f);
        }
    }

    //Gets the number of minutes difference between world time and the provided time
    //Mostly redundant function (May change to be used here rather than in each local file later)
    public int minutesDifference(DateTime comparedTo)
    {
        int difference = 0;
        TimeSpan span = WORLDTIME.Subtract(comparedTo);
        difference = (int)span.TotalMinutes;
        return difference;
    }

    //Checks to see if the current world time is between two times.
    public bool isBetweenTimes(DateTime start, DateTime end)
    {
        //Too early
        if (WORLDTIME < start)
        {
            return false;
        }
        //Too late
        else if (WORLDTIME > end)
        {
            return false;
        }
        return true;
    }
}
