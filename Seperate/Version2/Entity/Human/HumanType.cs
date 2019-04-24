using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 08/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* ### Inherited Items ###
 */
/* Public Functions & Variables: 
 *      public bool isBedTime(DateTime worldTime)
 *      public bool isTimeToWakeUp(DateTime worldTime)
 *      public void wentToSleep(DateTime worldTime);
 */

/*Purpose: 
 *      Human data specific to their type, alliegances, political beliefs, etc
 *To Use: 
 *      TBD
 *To Do: 
 *      Look into political horse shoe? MUCH more research required on this front
 *      Struct containing name and other such details
 *      
 * More notes
 * 1. It holds the variables necessary for each type. E.G. A human
 *      may be part of one or more factions.
 */
public class HumanType : EntityType {
    public string Name;         //Humans name, might have to change to struct containing first and last names later, titles, ranks, etc
    public Gender gender;       //Entities gender, also used in the initialisation of the UMA asset
    public DateTime bedTime;    //The time that the entity will generally go to sleep

    public  DateTime wakeUpTime;   //Used to check if the human has had at least 8 hours sleep
    //public HumanBehaviourList mainBehaviour

    public bool isBedTime(DateTime worldTime)
    {
        TimeSpan difference = bedTime.TimeOfDay - worldTime.TimeOfDay;      //How long is left until bedTime
        TimeSpan threshold = new TimeSpan(0, 0, 0);                         //ZEROED Timespan for if statement comparison
        //if the difference is negative its time for bed
        if(difference < threshold)
        {
            return true;
        }
        return false;
    }
    public bool isTimeToWakeUp(DateTime worldTime)
    {
        TimeSpan difference = wakeUpTime.TimeOfDay - worldTime.TimeOfDay;   //How long is left until wake up time
        TimeSpan threshold = new TimeSpan(0, 0, 0);                         //ZEROED Timespan for if statement comparison
        //if the difference is negative its time for bed
        if (difference < threshold)
        {
            return true;
        }
        return false;
    }
    public void wentToSleep(DateTime worldTime)
    {
        wakeUpTime = worldTime;
        wakeUpTime.AddHours(8);
    }

    public HumanSave saveHumanData(HumanSave save)
    {
        save.Name = Name;
        save.gender = gender;
        save.bedTime = bedTime;
        return save;
    }
    public HumanType(HumanSave load)
    {
        Name = load.Name;
        gender = load.gender;
    }
    public HumanType()
    {
        Name = "Veronica";
        gender = Gender.Female;
        bedTime = new DateTime();
        wakeUpTime = new DateTime();
    }
}
